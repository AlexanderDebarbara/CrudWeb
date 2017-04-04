using MatriculaWeb.Repositorio.Excecao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatriculaWeb.Repositorio.Util
{
    public static class CpfCnpj
    {
        public static void ChecarCpf(string cpf)
        {
            if (!IsCpfValido(cpf))
                throw new CpfCnpjException("Cpf Inválido");
        }

        public static void ChecarCnpj(string cnpj)
        {
            if (!IsCnpjValido(cnpj))
                throw new CpfCnpjException("Cnpj em Formato Inválido");
        }

        public static bool IsCpfValido(string cpf)
        {
            string numerosCpfSemFormato = "";
            int[] arrayPrimeiroDigito = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] arraySegundoDigito = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int calculoPrimeiroDigito = 0, calculoSegundoDigito = 0, primeiroDigito = 0, segundoDigito = 0, resultadoPrimeiroDigito = 0, resultadoSegundoDigito = 0; ;
            try
            {
                for (int i = 0; i < cpf.Length; i++)
                    if (Char.IsDigit(Convert.ToChar(cpf[i])))
                        numerosCpfSemFormato += cpf[i];

                if (!IsSequenciaValida(numerosCpfSemFormato))
                    return false;

                if (numerosCpfSemFormato.Length != 11)
                    return false;

                for (int j = 0; j < arrayPrimeiroDigito.Length; j++)
                    calculoPrimeiroDigito += Convert.ToInt32(numerosCpfSemFormato[j].ToString()) * arrayPrimeiroDigito[j];

                for (int k = 0; k < arraySegundoDigito.Length; k++)
                    calculoSegundoDigito += Convert.ToInt32(numerosCpfSemFormato[k].ToString()) * arraySegundoDigito[k];

                resultadoPrimeiroDigito = calculoPrimeiroDigito % 11;

                if (resultadoPrimeiroDigito < 2)
                    resultadoPrimeiroDigito = 0;
                else
                    resultadoPrimeiroDigito = 11 - resultadoPrimeiroDigito;

                resultadoSegundoDigito = calculoSegundoDigito % 11;

                if (resultadoSegundoDigito < 2)
                    resultadoSegundoDigito = 0;
                else
                    resultadoSegundoDigito = 11 - resultadoSegundoDigito;

                primeiroDigito = Convert.ToInt32(numerosCpfSemFormato.Substring(9, 1));
                segundoDigito = Convert.ToInt32(numerosCpfSemFormato.Substring(10, 1));

                return ((resultadoPrimeiroDigito == primeiroDigito) && (resultadoSegundoDigito == segundoDigito));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static bool IsCnpjValido(string cnpj)
        {
            string numerosCnpjSemFormato = "";
            int[] arrayPrimeiroDigito = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] arraySegundoDigito = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int calculoPrimeiroDigito = 0, calculoSegundoDigito = 0, primeiroDigito = 0, segundoDigito = 0, resultadoPrimeiroDigito = 0, resultadoSegundoDigito = 0;
            try
            {
                for (int i = 0; i < cnpj.Length; i++)
                    if (Char.IsDigit(Convert.ToChar(cnpj[i])))
                        numerosCnpjSemFormato += cnpj[i];

                if (!IsSequenciaValida(numerosCnpjSemFormato))
                    return false;

                if (numerosCnpjSemFormato.Length != 14)
                    return false;

                for (int i = 0; i < arrayPrimeiroDigito.Length; i++)
                    calculoPrimeiroDigito += Convert.ToInt32(numerosCnpjSemFormato[i].ToString()) * arrayPrimeiroDigito[i];

                for (int j = 0; j < arraySegundoDigito.Length; j++)
                    calculoSegundoDigito += Convert.ToInt32(numerosCnpjSemFormato[j].ToString()) * arraySegundoDigito[j];

                resultadoPrimeiroDigito = calculoPrimeiroDigito % 11;

                if (resultadoPrimeiroDigito < 2)
                    resultadoPrimeiroDigito = 0;
                else
                    resultadoPrimeiroDigito = 11 - resultadoPrimeiroDigito;

                resultadoSegundoDigito = calculoSegundoDigito % 11;

                if (resultadoSegundoDigito < 2)
                    resultadoSegundoDigito = 0;
                else
                    resultadoSegundoDigito = 11 - resultadoSegundoDigito;

                primeiroDigito = Convert.ToInt32(numerosCnpjSemFormato.Substring(12, 1));
                segundoDigito = Convert.ToInt32(numerosCnpjSemFormato.Substring(13, 1));

                return ((resultadoPrimeiroDigito == primeiroDigito) && (resultadoSegundoDigito == segundoDigito));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static bool IsSequenciaValida(string sequencia)
        {
            for (int i = 1; i < sequencia.Length; i++)
                if (!sequencia[i].Equals(sequencia[i - 1]))
                    return true;

            return false;
        }
    }
}
