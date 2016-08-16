using System;
using FlakeGen;

namespace Flake
{
    public sealed class IdGen
    {
        private static volatile Id64Generator FlakeGen;
        private static object syncRoot = new Object();

        private IdGen() { }

        public static Id64Generator Instance
        {
            get
            {
                if (FlakeGen == null)
                {
                    lock (syncRoot)
                    {
                        if (FlakeGen == null)
                        {
                            FlakeGen = new Id64Generator(generatorId: 0);
                        }
                    }
                }

                return FlakeGen;
            }
        }
    }
}
