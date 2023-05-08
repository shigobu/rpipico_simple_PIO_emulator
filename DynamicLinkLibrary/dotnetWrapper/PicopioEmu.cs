namespace DotnetWrapper
{
    /// <summary>
    /// PIOエミュレータ
    /// </summary>
    public class PicopioEmu
    {
        /// <summary>
        /// エミュレータのオプション機能を設定します。
        /// </summary>
        /// <param name="outGpioBitByBit"></param>
        /// <param name="inGpioBitByBit"></param>
        /// <param name="dispAsmStdout"></param>
        /// <param name="distpTraceStdout"></param>
        /// <remarks>
        /// オプション機能を使わない場合は、呼び出し不要です。
        /// </remarks>
        public static void Init(bool outGpioBitByBit, bool inGpioBitByBit, bool dispAsmStdout, bool distpTraceStdout)
        {
            NativeMethod.pio_init(outGpioBitByBit, inGpioBitByBit, dispAsmStdout, distpTraceStdout);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="funcname"></param>
        /// <param name="smId"></param>
        /// <param name="inPins"></param>
        /// <param name="inNum"></param>
        /// <param name="outPins"></param>
        /// <param name="outNum"></param>
        /// <param name="sidesetPins"></param>
        /// <param name="sidesetNum"></param>
        /// <param name="sidesetOpt"></param>
        /// <param name="isrShiftRight"></param>
        /// <param name="isrAutopush"></param>
        /// <param name="isrAutopushThreshold"></param>
        /// <param name="osrShiftRight"></param>
        /// <param name="osrAutopull"></param>
        /// <param name="osrAutopullThreshold"></param>
        /// <param name="jmpPin"></param>
        /// <param name="movStatusSel"></param>
        /// <param name="movStatusVal"></param>
        public static void CodeStart(
                        string funcname,
                        int smId,                  // state machine ID (for IRQ rel)

                        int inPins,
                        int inNum,
                        int outPins,
                        int outNum,
                        int sidesetPins,
                        int sidesetNum,
                        bool sidesetOpt,

                        bool isrShiftRight,       // SHIFTCTRL_IN_SHITDIR
                        bool isrAutopush,
                        int isrAutopushThreshold, // SHIFTCTRL_PUSH_THRESH
                        bool osrShiftRight,       // SHIFTCTRL_OUT_SHIFTDIR
                        bool osrAutopull,
                        int osrAutopullThreshold, // SHIFTCTRL_PULL_THRESH
                        int jmpPin,                // EXECCTRL_JMP_PIN
                        bool movStatusSel,            // EXECCTRL_STATUS_SEL
                        int movStatusVal          // EXECCTRL_STATUS_SEL
            )
        {
            NativeMethod.pio_code_start(funcname, smId, inPins, inNum, outPins, outNum, sidesetPins, sidesetNum, sidesetOpt, isrShiftRight, isrAutopush, isrAutopushThreshold, osrShiftRight, osrAutopull, osrAutopullThreshold, jmpPin, movStatusSel, movStatusVal);
        }
    }
}
