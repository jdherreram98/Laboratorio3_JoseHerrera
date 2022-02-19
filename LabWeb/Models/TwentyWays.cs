using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace LabWeb.Models
{
    public class TwentyWays
    {
        private const string Abc = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz";
        public string Word { get; set; }

        public void GenerateWord()
        {
            StringBuilder pWord = new StringBuilder();
            // for with tochar
            pWord.Append(V_Generation("Victoria"));
            // recursive
            pWord.Append(i_Generation(Abc));
            // by index
            pWord.Append(s_Generation(Abc, 37));
            // read txt
            pWord.Append(u_Generation());
            // read pdf
            pWord.Append(a_Generation());
            // read json
            pWord.Append(l_Generation("{'Character': 'l'}"));
            // search space on an array
            List<char> array = new List<char> { 'S', ' ', '9', 'J', '1', 'H', 'r' };
            pWord.Append(space1_Generation(array));
            // get from an queue
            Queue<char> queueCopy = new Queue<char>(array.ToArray());
            pWord.Append(S_Generation(queueCopy));
            // search for matrix
            char[,] matr = new char[2, 3] { { 'T', 't', 'r' }, { 'n', 'h', 'k' } };
            pWord.Append(t_Generation(matr));
            // get from ascii
            pWord.Append(u2_Generation());
            // dictionary
            var dictionary = new Dictionary<string, char> { { "character", 'd' }, { "character2", 'J' }, { "character3", 't' } };
            pWord.Append(d_Generation(dictionary));
            // by param
            pWord.Append(i2_Generation('i'));
            // search by string splited by ,
            pWord.Append(o_Generation("a,1,8,s,p,i,2,o,z"));
            // get comma by xml
            pWord.Append(comma_Generation("<XML ID='MyXMLDocument'><object><character>,</character></object></XML>  "));
            // get space by object
            ObjectClass object_c = new ObjectClass { Character = ' ' };
            pWord.Append(space2_Generation(object_c));
            // multiply by two params
            pWord.Append(two_Generation(2, 1));
            // regex
            pWord.Append(cero_Generation("1234567890"));
            // subtraction by two params
            pWord.Append(two2_Generation(8, 6));
            // random
            pWord.Append(two3_Generation());
            // web scrapping
            pWord.Append(dot_Generation());

            Word = pWord.ToString();
        }

        /// <summary>
        /// get char V by searching in an string using for to ToCharArray
        /// </summary>
        /// <returns> return V letter</returns>
        public char V_Generation(string pString)
        {
            char[] chars = pString.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i].Equals('V'))
                    return chars[i];

            }

            return ' ';
        }

        /// <summary>
        /// generation by recursive i
        /// </summary>
        /// <param name="pString"></param>
        /// <returns></returns>
        public char i_Generation(string pString)
        {
            string character = pString.Substring(0, 1);

            if (!character.Equals("i"))
            {
                pString = pString.Replace(character, "");
                return i_Generation(pString);
            }

            return char.Parse(character);

        }

        /// <summary>
        /// get char s using searching by index
        /// </summary>
        /// <param name="pString"></param>
        /// <param name="pIndex"></param>
        /// <returns></returns>
        public char s_Generation(string pString, int pIndex)
        {
            string character = pString.Substring(pIndex, 1);

            if (character.Equals("s"))
                return char.Parse(character);

            return ' ';

        }

        /// <summary>
        /// get char u using txt
        /// </summary>
        /// <param name="pString"></param>
        /// <param name="pIndex"></param>
        /// <returns></returns>
        public char u_Generation()
        {
            try
            {
                string text = File.ReadAllText("../../../Misc/text.txt");

                if (text.Equals("u"))
                    return char.Parse(text);
            }
            catch (Exception err)
            {
                Console.WriteLine($"error : {err.Message}");
            }

            return ' ';
        }

        /// <summary>
        /// get char u using pdf
        /// </summary>
        /// <param name="pString"></param>
        /// <param name="pIndex"></param>
        /// <returns></returns>
        public char a_Generation()
        {
            try
            {
                string text = File.ReadAllText("../../../Misc/textpdf.pdf");

                if (text.Equals("a"))
                    return char.Parse(text);
            }
            catch (Exception err)
            {
                Console.WriteLine($"error : {err.Message}");
            }

            return ' ';
        }

        /// <summary>
        /// read json string
        /// </summary>
        /// <returns> </returns>
        public char l_Generation(string pString)
        {
            try
            {
                var json = JsonConvert.DeserializeObject<JsonClass>(pString);

                if (json.Character.Equals('l'))
                    return json.Character;
            }
            catch (Exception err)
            {
                Console.WriteLine($"error : {err.Message}");
            }

            return ' ';
        }

        /// <summary>
        /// get char space by searching in an array of strings
        /// </summary>
        /// <returns></returns>
        public char space1_Generation(List<char> pStringList)
        {
            char result = pStringList.Find(x => x.Equals(' '));

            if (result.Equals(' '))
                return result;

            return ' ';
        }

        /// <summary>
        /// get char S space by queue
        /// </summary>
        /// <returns></returns>
        public char S_Generation(Queue<char> pQueue)
        {
            char result = pQueue.Peek();

            if (result.Equals('S'))
                return result;

            return ' ';
        }

        /// <summary>
        /// get char t matrix
        /// </summary>
        /// <returns></returns>
        public char t_Generation(char[,] pMatr)
        {
            for (int k = 0; k < pMatr.GetLength(0); k++)
                for (int l = 0; l < pMatr.GetLength(1); l++)
                    if (pMatr[k, l].Equals('t'))
                        return 't';

            return ' ';
        }

        /// <summary>
        /// get from ascii
        /// </summary>
        /// <returns></returns>
        public char u2_Generation()
        {
            int unicode = 117;
            return (char)unicode;
        }

        /// <summary>
        /// get char d on dictionary
        /// </summary>
        /// <returns></returns>
        public char d_Generation(Dictionary<string, char> pDictionary)
        {
            foreach (KeyValuePair<string, char> item in pDictionary)
            {
                if (item.Value.Equals('d'))
                    return item.Value;
            }

            return ' ';
        }

        /// <summary>
        /// return the char i by param
        /// </summary>
        /// <returns></returns>
        public char i2_Generation(char pChar)
        {
            return pChar;
        }

        /// <summary>
        /// get char o search by string splited by ,
        /// </summary>
        /// <returns></returns>
        public char o_Generation(string pString)
        {
            string [] result = pString.Split(',');

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i].Equals("o"))
                    return char.Parse(result[i]);
            }

            return ' ';
        }

        /// <summary>
        /// read an xml
        /// </summary>
        /// <returns> </returns>
        public char comma_Generation(string pXml)
        {
            try
            {
                using (StringReader stringReader = new StringReader(pXml))
                {
                    XDocument xdoc = XDocument.Load(stringReader);
                    var _object = xdoc.Descendants("object");
                    var character = _object.Where(item => item.Element("character").Value == ",").FirstOrDefault();
                    if (character.Value.Equals(","))
                        return char.Parse(character.Value);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine($"error : {err.Message}");
            }

            return ' ';
        }

        /// <summary>
        /// read object if contains space
        /// </summary>
        /// <returns> </returns>
        public char space2_Generation(ObjectClass pObject)
        {
            try
            {
                if (pObject.Character.Equals(' '))
                    return pObject.Character;
            }
            catch (Exception err)
            {
                Console.WriteLine($"error : {err.Message}");
            }

            return ' ';
        }

        /// <summary>
        /// get 2 by multiply two numbers
        /// </summary>
        /// <param name="pNumber"></param>
        /// <param name="pNumber2"></param>
        /// <returns></returns>
        public char two_Generation(int pNumber, int pNumber2)
        {
            int result = pNumber * pNumber2;

            if (result.Equals(2))
                return char.Parse(result.ToString());

            return ' ';

        }

        /// <summary>
        /// get char using regex
        /// </summary>
        /// <param name="pString"></param>
        /// <returns></returns>
        public char cero_Generation(string pString)
        {
            Regex rx = new Regex(@"[0]");

            string match = rx.Match(pString).Value;
            if (match.Equals("0"))
                return char.Parse(match);

            return ' ';

        }

        /// <summary>
        /// get 2 by subtraction two numbers
        /// </summary>
        /// <param name="pNumber"></param>
        /// <param name="pNumber2"></param>
        /// <returns></returns>
        public char two2_Generation(int pNumber, int pNumber2)
        {
            int result = pNumber - pNumber2;

            if (result.Equals(2))
                return char.Parse(result.ToString());

            return ' ';

        }

        /// <summary>
        /// get 2 by random
        /// </summary>
        /// <returns></returns>
        public char two3_Generation()
        {
            Random randomClass = new Random();

            int result;
            do
            {
                result = randomClass.Next(0, 3);
            } while (result != 2);

            return char.Parse(result.ToString());

        }

        /// <summary>
        /// get dot by web scraping
        /// </summary>
        /// <returns></returns>
        public char dot_Generation()
        {
            var url = "https://visualstudio.microsoft.com/es/";
            var web = new HtmlWeb();
            var doc = web.Load(url).Text;

            if (doc.Contains('.'))
                return '.';

            return ' ';

        }



        public override string ToString()
        {
            return Word;
        }

    }
}
