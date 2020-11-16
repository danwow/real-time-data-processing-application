using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto_IB1
{
    public class BufferCircular
    {
        double[][] buffer;
        int tamBuffer;
        public int contAmostras;
        int pwr, prd;

        //construtor
        public BufferCircular(int tam)
        {
            tamBuffer = tam;
            buffer = new double[tam][];
            pwr = 0; prd = 0; contAmostras = 0; //escrever, ler, contar
        }

        //escreve a amplitude e o tempo na variável val[x y]
        public bool push(double[] val)
        {   //guarda no buffer um valor x e y (tempo e amplitude)
            bool continuar = true; //é vdd essa aquisição
            buffer[pwr] = new double[2] { val[0], val[1] }; //valor de x e y
            if (contAmostras >= tamBuffer - 1)  //o buffer está lotado, verifica se vai sobrescrever 
            {
                continuar = false; //o buffer continua o msm tamanho, mas sobrescreveu (stop)
            }
            else //caso não tenha lotado (se é vdd essa aquisição)
                contAmostras++; //incremento uma amostra no buffer (head)

            pwr++; //incremento o ponteiro para a próxima posição
            if (pwr > tamBuffer - 1) //mas se já tava na última posição
                pwr = 0; //faço o ponteiro circular, ou seja, volta à primeira posição
            return continuar;//true = tudo ok , false = perdendo dados            
        }

        //PUSH - POP ~~> Pegar informação - Ler informação

        public bool pop(ref double[] v) //passagem de valor por referencia, mando para pop o end de memoria do vetor v, vai escrever na variavel q chamou
        {
            if (contAmostras == 0)
                return false; //não tem nada para ler
            else
            {
                v[0] = buffer[prd][0];
                v[1] = buffer[prd][1];
                contAmostras--; //li uma linha do buffer atrás da head do push (tail)
                prd++; //passo para a próxima linha de leitura
                if (prd > tamBuffer - 1) //se chegou no final do buffer
                    prd = 0; //solta pro começo
                return true;
            }
        }
    }
}

