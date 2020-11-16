using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;//biblioteca para manipulação do gráfico
using System.IO.Ports;  //necessário para ter acesso as portas 
using System.IO;        //manipulação de arquivos
using System.Threading; //pra usar threads

namespace Projeto_IB1
{
    public partial class Form1 : Form
    {
        ChartArea areaGrafico; // manipular os parâmetros do gráfico
        Series sinal; //série que será desenhada no gráfico
        double auxEixox = 0;
        double contSerial = 0;
        double ampEscala;
        int cont = 0;
        //int tempinho;

        BufferCircular BC;
        double[] y;

        uint bits = 16; // 2^16 = 65536
        int escala;

        Mutex m; //Mututal Execution evita que duas threads utilizem a mesma função ao msm tempo
        double[] vetSinal;
        double sampfreq = 50;

        int LSB, MSB;
        SerialPort serial;

        bool runThAq, runThPlot, flagStart, flagLife;
        Thread thrAq, thrPlot;

        //StreamWriter file;
        //const string nome = "ECG1.txt";// Nome do aquivo .txt que grava os dados do primeiro canal de ECG
        //string path = "C:/Users/Admin/Desktop/Projeto IB1/Projeto IB1" + nome;
        
        public Form1()
        {
            runThAq = true; //é verdade essa aquisição
            runThPlot = true;
            flagStart = true;
            flagLife = true;

            thrAq = new Thread(aquisicao);
            thrAq.Priority = ThreadPriority.Normal;
            thrPlot = new Thread(plotagem);
            thrPlot.Priority = ThreadPriority.Normal;

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BC = new BufferCircular(10000); //criando o objeto do buffer circular 

            escala = (int)Math.Pow(2, bits);
            m = new Mutex();
            vetSinal = new double[escala];

            serial = new SerialPort();
            cbCOM.Items.AddRange(SerialPort.GetPortNames());

            InicializaGrafico();
        }

        private void atualizaListaCOMs()
        {
            int i;
            bool quantDiferente; //flag para sinalizar que a quantidade de portas mudou

            i = 0;
            quantDiferente = false;

            //se a quantidade de portas mudou
            if (cbCOM.Items.Count == SerialPort.GetPortNames().Length)
            {
                foreach (string s in SerialPort.GetPortNames())
                {
                    if (cbCOM.Items[i++].Equals(s) == false)
                    {
                        quantDiferente = true;
                    }
                }
            }
            else
            {
                quantDiferente = true;
            }

            //Se não foi detectado diferença
            if (quantDiferente == false)
            {
                return;                     //retorna
            }

            //limpa comboBox
            cbCOM.Items.Clear();

            //adiciona todas as COM diponíveis na lista
            foreach (string s in SerialPort.GetPortNames())
            {
                cbCOM.Items.Add(s);
            }
            //seleciona a primeira posição da lista
            cbCOM.SelectedIndex = 0;
        }

        private void InicializaGrafico()
        {
            //Limpar qq chartArea ou Series que já existe no gráfico
            grafico.ChartAreas.Clear(); //Limpa as áreas
            grafico.Series.Clear(); //Limpa as séries

            //Cria uma nova séries com um nome específico que serve para identificaçãO
            sinal = new Series("Potenciômetro");
            //Definindo o tipo de série 
            //FastLine garante melhor desempenho
            sinal.ChartType = SeriesChartType.FastLine; //fastline para desenhar mais rápido, vai interpolar os pontos e gera uma linha/curva
            sinal.BorderWidth = 2; //espessura
            //Adiciona a nova série ao gráfico
            grafico.Series.Add(sinal);

            //Cria uma nova chartArea com um nome específico
            areaGrafico = new ChartArea("ECG");
            //Configurando os nomes do eixos
            areaGrafico.AxisX.Title = "Tempo (s)";
            areaGrafico.AxisY.Title = "Amplitude (V)";
            //Configurando os limites do gráfico
            areaGrafico.AxisX.Minimum = 0; //min X
            areaGrafico.AxisX.Maximum = 10;//max x
            auxEixox = areaGrafico.AxisX.Maximum - areaGrafico.AxisX.Minimum; //Continuar com o mesmo tamanho de janela
            //areaGrafico.AxisY.Minimum = -0.3;//min y
            //areaGrafico.AxisY.Maximum = 0.3;//max y
            //Adiciona a nova área ao gráfico
            grafico.ChartAreas.Add(areaGrafico);
        }

        //delegate que encapsula um métodos
        //duas propriedade q esta declarando, vai estanciar nessa funçao em cima setText_label_bytesToRead
        public delegate void setText_label_bytesToRead_delegate(string s);
        public setText_label_bytesToRead_delegate delegateHandler_setTextLabelbytesToRead;

        //delegate para acesso ao label lbBytestoRead
        public void setText_label_bytesToRead(string s)
        {
            //check if this method is running on a different thread
            //than the thread that created the control
            if (lbBytestoRead.InvokeRequired)
            {
                //instanciando o delegado
                delegateHandler_setTextLabelbytesToRead = new setText_label_bytesToRead_delegate(setTextLabelBytesToRead);
                //invoka o delegado
                lbBytestoRead.BeginInvoke(delegateHandler_setTextLabelbytesToRead, new object[] { s });
            }
            else
                lbBytestoRead.Text = s;
        }
        private void setTextLabelBytesToRead(string s)
        {
            lbBytestoRead.Text = s;
        }


        public void setText_label_lbEspBuf(string s)
        {
            //check if this method is running on a different thread
            //than the thread that created the control
            if (lbEspBuf.InvokeRequired)
            {
                //instanciando o delegado
                delegateHandler_setTextLabellbEspBuf = new setText_label_lbEspBuf_delegate(setTextLabellbEspBuf);
                //invoka o delegado
                lbEspBuf.BeginInvoke(delegateHandler_setTextLabellbEspBuf, new object[] { s });
            }
            else
                lbEspBuf.Text = s;
        }

        //delegate que encapsula um métodos
        //duas propriedade q esta declarando
        public delegate void setText_label_lbEspBuf_delegate(string s);
        public setText_label_lbEspBuf_delegate delegateHandler_setTextLabellbEspBuf;

        private void setTextLabellbEspBuf(string s)
        {
            lbEspBuf.Text = s;
        }

        private void aquisicao()
        {
            while (flagLife)
            {
                while (runThAq)
                {
                    //Lê um byte do arduino
                    int a = serial.BytesToRead;
                    setText_label_bytesToRead(a.ToString());
                    if (a > 2)
                    {
                        for (int i = 0; i < a; i+=2)
                        {

                            LSB = serial.ReadByte();
                            MSB = serial.ReadByte();
                            int amp = ((MSB << 8) + LSB);

                            ampEscala = (amp * 5.0 / 1023);
                            setText_label_amp(Math.Round(ampEscala, 3).ToString()); // arredondamento para 3 casas decimais

                            y = new double[2];
                            y[0] = ampEscala;
                            y[1] = contSerial;

                            //tempinho = Convert.ToInt16(y[1]);
                            //file.WriteLine(tempinho.ToString() + "; " + y[0].ToString());

                            //tempo de arduino 
                            contSerial += 1.0 / (sampfreq);
                            BC.push(y);
                        }

                    }
                }
            }
        }


        #region delegate para acesso ao label lbBytestoRead
        public void setText_label_amp(string s)
        {
            //check if this method is running on a different thread
            //than the thread that created the control
            if (lbAmp.InvokeRequired)
            {
                //instanciando o delegado
                delegateHandler_setTextamp = new setText_label_amp_delegate(setTextLabelamp);
                //invoka o delegado
                lbAmp.BeginInvoke(delegateHandler_setTextamp, new object[] { s });
            }
            else
                lbAmp.Text = s;
        }    

        //delegate que encapsula um métodos
        //duas propriedade q esta declarando, vai estanciar nessa funçao em cima setText_label_bytesToRead
        public delegate void setText_label_amp_delegate(string s);
        public setText_label_amp_delegate delegateHandler_setTextamp;
        private void setTextLabelamp(string s)
        {
            lbAmp.Text = s;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            flagLife = false;
            runThAq = false;
            runThPlot = false;
            //runThFFT = false;

            byte[] dado = new byte[1];
            dado[0] = 50;
            serial.Write(dado, 0, 1);
            //file.Close();
        }
        
        private void cbCOM_Click(object sender, EventArgs e)
        {
            atualizaListaCOMs();
        }

        private void btnFIM_Click(object sender, EventArgs e)
        {
            flagLife = false;
            runThAq = false;
            runThPlot = false;

            byte[] dado = new byte[1];
            dado[0] = 50;
            serial.Write(dado, 0, 1);
            //file.Close();
        }
        #endregion

        #region para o acesso a chartPlot
        public void setSinal(double t, double s)
        {
            //check if this method is running on a different thread
            //than the thread that created the control
            if (grafico.InvokeRequired)
            {
                //instanciando o delegado
                delegateHandler_setSinal = new setSinal_delegate(set_Sinal);
                //invoka o delegado
                grafico.BeginInvoke(delegateHandler_setSinal, new object[] { t, s });
            }
            else
            {
                if (t > areaGrafico.AxisX.Maximum)
                {
                    sinal.Points.RemoveAt(0); //Removo o primeiro ponto da série
                    areaGrafico.AxisX.Maximum = Math.Round(t, 3); //Faço com que o máximo do eixo x seja o próprio contador
                    areaGrafico.AxisX.Minimum = Math.Round(areaGrafico.AxisX.Maximum - auxEixox, 3); //O mínimo passa a ser o máximo menos a largura inicial
                    areaGrafico.AxisX.LabelStyle.Format = "#";
                }
                sinal.Points.AddXY(t, s);
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void cbCOM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //delegate que encapsula um métodos
        //duas propriedade q esta declarando
        public delegate void setSinal_delegate(double x, double s);

        
        public setSinal_delegate delegateHandler_setSinal;
        private void set_Sinal(double t, double s)
        {
            //Se o contador/tempo de amostragem for maior que o máximo do eixo X
            if (t > areaGrafico.AxisX.Maximum)
            {
                sinal.Points.RemoveAt(0); //Removo o primeiro ponto da série
                areaGrafico.AxisX.Maximum = Math.Round(t, 1); //Faço com que o máximo do eixo x seja o próprio contador
                areaGrafico.AxisX.Minimum = Math.Round(areaGrafico.AxisX.Maximum - auxEixox, 1); //O mínimo passa a ser o máximo menos a largura inicial
            }
            sinal.Points.AddXY(t, s);
        }
        #endregion

        void plotagem()
        {
            while (flagLife)
            {
                while (runThPlot)
                {
                    
                    double[] y = new double[2];
                    if (cont < escala)
                    {
                        if (BC.pop(ref y))
                        {
                            //m.WaitOne();

                            lbTempo.Invoke(new Action(() => lbTempo.Text = (y[1].ToString())));
                            //Peço para que uma nova amostra seja gerada
                            //Pego os dados da nova amostra e adiciona à lista de pontos da série chamada sinal
                            setText_label_lbEspBuf(BC.contAmostras.ToString());
                            setText_label_amp(Math.Round(y[0], 3).ToString());
                            setSinal(y[1], y[0]); //Adiciono o novo vetor gerado (eixo x, eixo y)

                            
                            vetSinal[cont] = y[0];
                            cont++;
                            //m.ReleaseMutex();
                        }
                    }
                }
            }
        }


        private void btIniciar_Click(object sender, EventArgs e)
        {

            //Abrir a conexão com a porta COM selecionada na combobox
            //pega os itens da combobox na posição que ela foi selecionada

            //Recuperando qual porta com está selecionada na combobox
            string portName = cbCOM.Items[cbCOM.SelectedIndex].ToString();
            //Abre a comunicação com a porta serial
            serial.PortName = portName;//passa a porta com para o objeto serial
            serial.BaudRate = 19200; //estabelece o baud rate da comunicação (115200)
            serial.Open(); //abre a comunicação

            if (flagStart)
            {
                thrAq.Start();
                thrPlot.Start();
                flagStart = false;
                serial.DiscardOutBuffer();
                serial.DiscardInBuffer();
            }

            byte[] dado = new byte[1]; //cria um vetor de bytes com o dado
            dado[0] = 100; //coloca o valor 100 na primeira posição
            serial.Write(dado, 0, 1); //envia o dado, ela precisa de um vetor de dados, a partir de qual vetor quer enviar e a qntt de dados
            runThAq = true;            
            runThPlot = true;

            //file = new StreamWriter(path, false);
        }
    }
}
