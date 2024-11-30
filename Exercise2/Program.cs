namespace Exercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pathToDirectory = "C:\\Users\\Feona\\Desktop\\Учеба скилфактори";
            double catalogSize = 0;
            catalogSize = sizeOfFolder(pathToDirectory, ref catalogSize); 
            if (catalogSize != 0)
            {
                Console.WriteLine("Размер папки {0} составляет {1} Байт", pathToDirectory, catalogSize);
            }
            else
            {
                Console.WriteLine("Каталог {0} пуст.", pathToDirectory);
            }
            Console.ReadLine();
        }

        static double sizeOfFolder(string folder, ref double catalogSize)
        {
            try
            {
                
                DirectoryInfo di = new DirectoryInfo(folder);
                DirectoryInfo[] diA = di.GetDirectories();
                FileInfo[] fi = di.GetFiles();
                
                foreach (FileInfo f in fi)
                {
                   
                    catalogSize = catalogSize + f.Length;
                }
                
                foreach (DirectoryInfo df in diA)
                {
                    
                    sizeOfFolder(df.FullName, ref catalogSize);
                }
                
                return Math.Round((double)(catalogSize ), 1);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Директория не найдена. Ошибка: " + ex.Message);
                return 0;
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Отсутствует доступ. Ошибка: " + ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка. Обратитесь к администратору. Ошибка: " + ex.Message);
                return 0;
            }
        }
    }


}