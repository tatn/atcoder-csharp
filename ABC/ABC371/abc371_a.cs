namespace AtCoderCsharp.ABC.ABC371
{
    // 	A - Jiro
    internal class abc371_a
    {
        public static void Main(string[] args)
        {
            string[] ReadStringArray() => Console.ReadLine()!.Split();

            string[] S = ReadStringArray();

            switch (S[0])
            {
                case "<":
                    // A < B

                    if (S[1] == "<")
                    {
                        // A < C

                        if (S[2] == "<")
                        {
                            // B < C

                            // A < B < C
                            Console.WriteLine("B");

                        }
                        else
                        {
                            // C < B

                            //  A < C < B
                            Console.WriteLine("C");
                        }
                    }
                    else
                    {
                        // C < A

                        // C < A < B

                        Console.WriteLine("A");
                    }


                    break;
                case ">":
                    // B < A

                    if (S[1] == "<")
                    {
                        // A < C

                        // B < A < C
                        Console.WriteLine("A");

                    }
                    else
                    {
                        // C < A

                        if (S[2] == "<")
                        {
                            // B < C

                            //   B < C < A
                            Console.WriteLine("C");



                        }
                        else
                        {
                            // C < B

                            //  C < B < A
                            Console.WriteLine("B");
                        }
                    }

                    break;
            }



        }
    }
}
