using System;
using System.Collections.Generic;
using con = System.Console;
using System.Threading;

namespace evo
{
    class Program
    {
        static int population = 5;

        static void Main(string[] args)
        {
            double[,] data = new double[,]
            {
                {0,1 },
                {1,1 }
            };


            con.WriteLine("Hello World!");

            List<Generation> generations = new List<Generation>();
            int i = 0;
            algo bestalgo = new algo();
            bestalgo.Mutate();

            int algocounter = 0;
            double algoerror = 100.0;
            //double lastalgoerror = 100.0;
            double besterror = 100;

            while (true)
            {
                i++;
                Generation gen = new Generation(population, bestalgo);
                gen.Mutate();
                generations.Add(gen);


                for (int i1 = 0; i1 < gen.algos.Length; i1++)
                {
                    con.WriteLine("Gen {0} Algo {1}", i, algocounter);

                    for (int x = 0; x < 2; x++)
                    {
                        for (int y = 0; y < 2; y++)
                        {
                            double res = gen.algos[i1].Run(x, y);
                            con.WriteLine("running with {0}{1} result: {2}", x, y, res);

                            double totalError = 0.0;
                            if (res != 0)
                            {
                                algoerror = (data[x, y] - res);
                                algoerror = Math.Abs(algoerror);
                                totalError += algoerror;
                                //con.WriteLine("algoerror: {0}", algoerror);
                                
                                //lastalgoerror = algoerror;
                            }
                            else
                            {
                                continue;
                            }
                            

                            if (totalError < besterror)
                            {
                                bestalgo = gen.algos[i1];
                                besterror = totalError;
                            }
                        }
                    }

                    con.WriteLine("total error: {0}", besterror);

                    algocounter++;
                }
                con.WriteLine("end of generation-----------\n\n\n");
                con.ReadLine();
                con.Clear();
            }


            con.ReadLine();
            con.WriteLine("EoP");
            con.ReadLine();
        }
    }
}
