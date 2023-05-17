using System.Linq;

namespace JJJ21
{
    internal class Program
    {
        // 가까운 거리 순으로 정렬 함수
        public static void SortArray(int[] array, int stand)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            // 제공 받은 배열 값을 딕셔너리 형태로 저장. 이때 키와 밸류의 값은 같다.
            for (int i = 0; i < array.Length; i++)
            {
                dictionary.Add(array[i], array[i]);
            }
            // 기준치로 제공 받은 정수에 밸류에 저장된 값들을 뺀 값을 절대 값으로 저장하여 거리를 구한 뒤, 밸류 영역에 저장한다.
            for (int i = 0; i < dictionary.Count; i++)
            {
                dictionary[array[i]] = Math.Abs(stand - dictionary[array[i]]);
            }
            // 절대값이 저장된 밸류를 내림차순으로 저장하여 거리가 가까운 순으로 정렬한 결과를 가지게 한다.
            dictionary = dictionary.OrderBy(item => item.Value).ToDictionary(x => x.Key, x => x.Value);

            // 결과 출력
            foreach (int i in dictionary.Keys)
            {
                Console.WriteLine($"키 값 : {i} 절대값 : {Math.Abs(stand - i)}");
            }

            // 배열로 받기 위해 배열 생성
            int[] result = new int[array.Length];
            // 생성한 배열에 키 값을 대입한다.
            for (int i = 0; i<result.Length; i++)
            {
                //result[i] = dictionary[array[i]].Keys;
            }
        }

        // 거리순으로 정렬 강사님 버전
        public static int[] SortNear(int[] array, int stand)
        {   
            /*
            // C스타일
            // 1. 내림차순 정렬 먼저(동일한 거리에 있을때 더 큰 수가 앞으로 오기 때문)
            // 2. 절대값을 계산한 후 해당 값을 기준으로 정렬

            for(int i=0; i<array.Length; i++)
            {
                for(int j=0; j < array.Length-1-i; j++)
                {
                    if (array[j] < array[j+1])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                
                }

            }

            // 오름차순 정렬 (기준값이 절대값)
            for(int i = 0; i<array.Length;i++)
            {
                for(int j =0; j < array.Length-i-1; j++)
                {
                    int left = Math.Abs(array[j]-stand);
                    int right = Math.Abs(array[j+1]-stand);
                    if(left > right)
                    {
                        int temp = array[j];
                        array[j] = array[j+1];
                        array[j+1] = temp;
                    }

                }
            }
            */

            // 함수 이용
            // 내림차 순 정렬
            // OrderByDescending(Func<T, Tkey) : 내림차순을 하는데 어떠한 값을 기준으로 하는가?
            var sort = array.OrderByDescending(num => num);

            return sort.OrderBy(num => Math.Abs(num - stand)).ToArray();

        }


        // 문자열에서 숫자만 빼서 정렬하기
        public static int[] ExtractNum(string str)
        {
            // c 스타일
            /*
            List<int> list = new List<int>();
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                // 문자 '0'~'9'
                if('0'<=c && c<='9')
                {
                    list.Add(c-'0');
                }
            }
            // 오름차순 정렬
            list.Sort();

            return list.ToArray();
*/

            // C#
            return str.Where(x => char.IsDigit(x)).Select(x => x - '0').OrderBy(c=>c).ToArray();

        }

        // Q. 소문자로 바꾸고 정렬하기
        public static void SortSmall(string str)
        {
            // 정렬을 위한 char 배열 생성
            char[] result = new char[str.Length];

            // 제공 받은 string을 소문자로 변경
            str = str.ToLower();

            // 소문자로 변경한 string을 char배열에 삽입
            result = str.ToArray();
            /*
            for (int i = 0; i < str.Length; i++)
            {
                result[i] = str[i];
            }
            */
            // 배열을 오름차순으로 정렬하고 출력
            Console.WriteLine(string.Join("",result.OrderBy(x => x)));

            // string을 정렬시킨 후 다시 string형태로 만드는 방법
            Console.WriteLine(new string(str.OrderBy(x => x).ToArray()));
        }



        static void Main(string[] args)
        {
            // 1교시
            /*
            int[] array = { 6, 80, 66, 99, 5051, 1253, 222 };

            SortArray(array, 233);

            string str = "가1나2다3라4";
            int[] arraystr = ExtractNum(str);
            arraystr.ToWriteLine();
            */

            string str = "asEZXChpodfODPfoD";

            SortSmall(str);

            // 람다식 복습
            Func<string, int> func = (string s) =>
            {
                return s.Length;
            };

            Func<string, int> func2 = s =>
            {
                return s.Length;
            };

            Func<string, int> func3 = s => s.Length;

            // Where : 조건
            // Select : 선택
            // OrderBy : 정렬
            // Count : 개수

            string teststr = "ABCDEFG";
            Console.WriteLine(string.Join("",teststr.Where(c=>c>='D')));
            Console.WriteLine(string.Join("",teststr.Select(c => (int)c)));
            Console.WriteLine(string.Join("",teststr.OrderBy(c => c)));
            Console.WriteLine(str.ToLower().Count(c => c == 'a'));



            // Q. 문자열에 포함 되어 있는 정수만 더하기

            string str1 = "aAb1B2cC34oOP";
            // var에 대입해서 자료형을 쉽게 알아낼 수 있다.
            // 'Home버튼' : 해당 열에서 커서를 최전방으로 이동 <-> 'END 버튼'
            var sumstr = str1.Where(c => char.IsDigit(c)).Select(c => (int)c-'0');

            Console.WriteLine(sumstr.Sum());


            // Q. 자릿수 더하기
            // 각 자리수의 정수를 더하여 산출하라.
            // ex) 1234를 제공 받았을 때, 1+2+3+4 = 10

            // 1. 문자열을 제공 받을 readline과 정수로만 이루어져있는지 체크하는 tryparse 써보기
            // 2. 문자열을 정수 배열로 정리하기
            // 3. 더하고 산출

        }


    }

    public static class Method
    {
        public static void ToWriteLine<T>(this T[] array)
        {
            foreach (T item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}