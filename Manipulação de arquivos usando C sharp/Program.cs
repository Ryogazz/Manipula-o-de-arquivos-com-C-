using System;
using System.IO;
using System.Globalization;
using Manipulação_de_arquivos.Entities;

namespace Manipulação_de_arquivos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the file path");
            //armazenado em sourceFIlePath o endereço do dado.
            string sourceFIlePath = Console.ReadLine();

            // try tentar, o progama tenta rodar o que esta dentro de try
            try
            {
                //criando o vetor lines e usando o comando file.ReadAllLines para que cada linha do
                //arquivo que esta armazenado dentro de sourceFilePath seja aemazenado como elementos do vetor.
                string[] lines = File.ReadAllLines(sourceFIlePath);

                Console.WriteLine("Itens para compra");
                //usando Foreach para que para cada string dentro do vetor lines seja indentificado e impresso.
                foreach (String line in lines)
                {
                    Console.WriteLine(line);
                }

                //Armazenando o caminho do arquivo de origem dentro de sourceFolderPath usando Path.GetDirectoryName que
                //Retorna as informações de diretório para a caminho especificado.
                string sourceFolderPath = Path.GetDirectoryName(sourceFIlePath);

                //Armazenando o caminho onde o arquivo sera armazenado
                string targetFolderPath = sourceFolderPath + @"\out";

                //Armazenando qual vai ser o nome do arquivo e onde ele vai ficar
                string targeFiletPath = targetFolderPath + @"\summary.csv";

                //criando a pasta do arquivo
                Directory.CreateDirectory(targetFolderPath);

                Console.WriteLine();


                //Usando Using para criar um bloco isolado dentro do codigo.
                //Usando StreamWriter que e um objeto que escreve um arquivo no caso o sw.
                //usando File.AppendText Um gravador de fluxo que acrescenta texto codificado para UTF-8
                //ao arquivo especificado ou a um novo arquivo. no caso ao (targeFiletPath)

                using (StreamWriter sw = File.AppendText(targeFiletPath))
                {
                    //usando Foreach para que para cada string dentro do vetor lines seja indentificado e impresso.
                    foreach (string line in lines)
                    {
                        //declarando o vetor x para que seja separado cada string do codigo em partes
                        string[] x = line.Split(';');
                        string name = x[0];
                        double price = double.Parse(x[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(x[2]);

                        //usando a classe product criada para armazenar separadamente os valores cortados com split
                        Product prod = new Product(name, price, quantity);
                        //usando sw.WriteLine para guardar dentro de sw somente os valores nome e total(que e um metodo
                        // da classe product que faz a multiplicação de price e quantity) separados por ";"
                        //e usando ToString junto de CultureInfo.InvariantCulture para guardar usando o "."
                        sw.WriteLine(prod.Name + ";" + prod.total().ToString("F2", CultureInfo.InvariantCulture));
                    }
                }
                //usando Foreach para que para cada string dentro do vetor lines2 seja indentificado e impresso.
                string[] lines2 = File.ReadAllLines(targeFiletPath);
                Console.WriteLine("Itens pos compra");
                foreach (String line in lines2)
                {
                    Console.WriteLine(line);
                }


            }
            //usando catch para guardar o IOException dentro de "e" e imprimir o erro caso o try falhe 
            // usando e.Message vamos saber exatamento qual erro foi
            catch (IOException e)
            {
                Console.WriteLine("AN ERROR OCCURRED");
                Console.WriteLine(e.Message);
            }

        }
    }
}
