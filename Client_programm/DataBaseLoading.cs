using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Дополнительные пространства имен
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace Client_programm
{
    class DataBaseLoading
    {
        int port = 12000;
        String hostName = "127.0.0.1";// local
        TcpClient client = null;// Ссылка на клиента
        string DataBaseName;

       public DataBaseLoading( string fromDataBaseNameTextBox)
        {
            DataBaseName = fromDataBaseNameTextBox;
            DataBaseCreating();
        }

        public void ReadLoadData()
        {
            try
            {
                // Создаем клиента, соединенного с сервером
                client = new TcpClient(hostName, port);
                // Сами задаем размеры буферов обмена (Необязательно!)
                //client.SendBufferSize = client.ReceiveBufferSize = 1024;
            }
            catch
            {
                MessageBox.Show("Сервер не готов!");
                return;
            }
            // Создаем потоки NetworkStream, соединенные с сервером
            NetworkStream streamIn = client.GetStream();
            NetworkStream streamOut = client.GetStream();
            StreamReader readerStream = new StreamReader(streamIn);
            StreamWriter writerStream = new StreamWriter(streamOut);

            // Отсылаем запрос серверу
            writerStream.WriteLine("4");
            writerStream.Flush();

            // Читаем ответ
            String receiverData;

            // Создаем поток для записи в текстовый файл - использовалось при отладке
            //StreamWriter sv = new StreamWriter(@"D:\Sveta\Programms\Out_file_client.txt");

            // разные объемы принимаемых данных - зависит от настроек сервера в методе ExecuteLoop(): (generalRows-groupCountRead)/groupCountRead*3000
            //for (int i = 1; i <= 107040000; i++)
            //for (int i = 1; i <= 5352000; i++)
            //for (int i = 1; i <= 2304000; i++)
            for (int i = 1; i <= 57000; i++)
                {
                // читаем из потока
                receiverData = readerStream.ReadLine();
                //Записываем строку в файл - использовалось при отладке
                //sv.WriteLine(receiverData);
                //записываем данные в БД
                DataBaseFilling(receiverData);

            }


            // Закрываем соединение и потоки, порядок неважен
            client.Close();
            writerStream.Close();
            readerStream.Close();
            //sv.Close(); //использовалось при отладке

            MessageBox.Show("Работа клиента закончена!");
        }

        // Метод создания БД
        private void DataBaseCreating()
        {
            String str;
            // Сервер - указать свои данные!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            SqlConnection myConn = new SqlConnection(@"Server=SVETLANA-BAYAND\SQLEXPRESS;Integrated security=SSPI;database=master");
            // Создаем БД
            str = "CREATE DATABASE " + DataBaseName;
            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                MessageBox.Show("База данных создана!", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myCommand.CommandType = CommandType.Text;
                    myCommand.CommandText = "CREATE TABLE " + DataBaseName + ".dbo.userData (ID int PRIMARY KEY, Ch_1 int, Ch_2 int, Ch_3 int, Ch_4 int, Ch_5 int, " +
                        "Ch_6 int, Ch_7 int, Ch_8 int, Ch_9 int, Ch_10 int, Ch_11 int, Ch_12 int, Ch_13 int, Ch_14 int, Ch_15 int, " +
                        "Ch_16 int, Ch_17 int, Ch_18 int, Ch_19 int, Ch_20 int, Ch_21 int, Ch_22 int, Ch_23 int, Ch_24 int, Ch_25 int, " +
                        "Ch_26 int, Ch_27 int, Ch_28 int, Ch_29 int, Ch_30 int, Ch_31 int, Ch_32 int, Ch_33 int, Ch_34 int, Ch_35 int, " +
                        "Ch_36 int, Ch_37 int, Ch_38 int, Ch_39 int, Ch_40 int, Ch_41 int, Ch_42 int, Ch_43 int, Ch_44 int, Ch_45 int, " +
                        "Ch_46 int, Ch_47 int, Ch_48 int, Beam_1 int, Beam_2 int, Deep int)";
                    myCommand.ExecuteNonQuery();
                    MessageBox.Show("Таблица создана!");
                    myConn.Close();
                }
            }
        }

        // Метод заполняющий БД
        private void DataBaseFilling(string receivedData)
        {
            //Делим полученную строку на части
            string[] receivedDataParts = receivedData.Split(new char[] { ' ' });
            string commandString =  "";
            // Известно, что в строке 51 число
            for (int i = 0; i<= 50; i++)
            {
                //формируем строку для будущего запроса
                commandString = commandString + receivedDataParts[i + 1] + ",";
            }
            commandString = commandString + receivedDataParts[52] ;
           //Подключаемся к БД, для "Data Source" свои параметры!!!!!!!!!!!!!!!!!
            string stringConnection = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=" + DataBaseName + @";Data Source=SVETLANA-BAYAND\SQLEXPRESS";
            SqlConnection myConn2 = new SqlConnection (stringConnection);
            SqlCommand myCommand2 = new SqlCommand();
            myCommand2.Connection = myConn2;
            //Добавляем в БД данные
            myCommand2.CommandText = "INSERT INTO dbo.userData VALUES (" + commandString + ")";
            myConn2.Open();
            myCommand2.ExecuteNonQuery();
            myConn2.Close();
            //MessageBox.Show("DataBaseFilling закончил работу!");
        }

    }
}
