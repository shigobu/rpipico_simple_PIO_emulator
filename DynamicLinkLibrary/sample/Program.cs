using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample
{
    //クラス名を省略するために、Emulatorクラスを継承している。
    class Program : PicopioEmu.Emulator
    {
        static void Main(string[] args)
        {
            //元の、defineスイッチの設定を行う。
            Init(false, false, true, true);

            CodeStartSimple("pio0_sm0", 0, UNUSE, UNUSE, UNUSE, UNUSE, 0, 3, false);
            WrapTarget();

            Nop(0x01, 0);
            Nop(0x02, 1);
            Nop(0x04, 2);

            Wrap();

            CodeEnd(true, "pio0_sm0.pio");

            RunEmulation(30, "in.csv", "out.csv");

            //そのままだとウィンドウが閉じてしまうので、入力待ちにしてウィンドウを閉じないようにする。
            Console.Read();
        }
    }
}
