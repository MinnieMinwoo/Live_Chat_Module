using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace ChatClient
{
    class Live_Chat
    {
        static void Main(string[] args)
        {
            // TcpClient를 선언합니다.
            TcpClient client = null;
            try
            {
                // client를 생성하고 원하는 ip주소로 연결합니다.
                client = new TcpClient();
                client.Connect("127.0.0.1", 34624);

                // GetStream을 사용하여 서버 내부의 데이터를 가져옵니다. NetworkStream을 가져온 후에는 보내고 받는다.
                NetworkStream stream = client.GetStream();
                // 인코딩 형식을 선택합니다.
                Encoding encode = Encoding.GetEncoding("utf-8");

                // 파일을 읽고 쓰기 위한 선언입니다. 네트워크의 stream을 가져옵니다.
                StreamWriter writeToServer = new StreamWriter(stream) { AutoFlush = true };
                StreamReader readFromServer = new StreamReader(stream, encode);

                // 콘솔의 문자를 읽어들입니다. 데이터는 서버로 전송됩니다.
                // string dataToServer = Console.ReadLine();

                // 데이터를 읽고 쓰는 과정을 반복합니다.
                while (true)
                {
                    writeToServer.WriteLine(dataToServer);
                    Console.WriteLine(readFromServer.ReadLine());
                    dataToServer = Console.ReadLine();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}