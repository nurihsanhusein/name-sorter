using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    class Program
    {

        static void Main(string[] args)
        {
            //declare the path of file text
            string path = args[0];
            Console.WriteLine("this file is:" + path);

            List<string> RawList = new List<string>();
            List<PersonModel> listofModel = new List<PersonModel>();
            List<PersonModel> Model2 = new List<PersonModel>();

            //Main
            using (StreamReader reader = new StreamReader(path))
            {

                Console.WriteLine(" ");
                Console.WriteLine("Unsorted Name:");
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    PersonModel personModel = new PersonModel();
                    string[] nameSplit = line.Split(new char[] { ' ' });
                    PutOnPersonModel(personModel, line, nameSplit);
                    RawList.Add(line);
                    listofModel.Add(personModel);
                    DisplayUnSortedName(line);
                }
            }
            Console.WriteLine(" ");
            Console.WriteLine("Sorted Name:");
            //SortByName(listofModel, Model2);
            Model2 = listofModel.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();
            DisplayImportSortedName(Model2);

        }

        ////Sort LastName
        //public static List<PersonModel> SortByName(List<PersonModel> listofModel, List<PersonModel> Model2)
        //{
        //    return Model2;
        //}
        //First,LastName and FullName perSonModel
        public static void PutOnPersonModel(PersonModel personModel, string line, string[] nameSplit)
		{
			personModel.FirstName =  nameSplit.First();
			personModel.LastName = nameSplit.Last();
			personModel.FullName = line;
		}
        //Display the UnsortedName
        static void DisplayUnSortedName(string line)
		{
			Console.WriteLine(line);
		}
		//Display and import the SortedName
		public static void DisplayImportSortedName(List<PersonModel> Model)
		{
			foreach (var item in Model)
			{
				Console.WriteLine(item.FullName);
            }
            Console.WriteLine(" ");
            Console.WriteLine("export to file .txt");
            TextWriter tw = new StreamWriter("sorted-names-list.txt");
            foreach (var item in Model)
            {
                tw.WriteLine(item.FullName);
            }
            tw.Close();
        }
    }
}
