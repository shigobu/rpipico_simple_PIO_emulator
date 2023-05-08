﻿namespace DotnetWrapper
{
    /// <summary>
    /// PIOエミュレータ
    /// </summary>
    public class PicopioEmu
    {
        /// <summary>
        /// in, out, mov で使用する。
        /// </summary>
        public enum Operands1
        {
            PINS = 100,
            X = 101,
            Y = 102,
            NULL = 103,
            ISR = 104,
            OSR = 105,
            PC = 106,
            EXEC = 107,
            PINDIRS = 108,
            STATUS = 109,
        }

        /// <summary>
        /// mov で使用する。
        /// </summary>
        public enum Operands2
        {
            NONE = 200,
            INVERT = 201,
            BIT_REVERSE = 202,
        }

        /// <summary>
        /// jmp で使用する。
        /// </summary>
        public enum Operands3
        {
            ALWAYS = 300,
            X_EQ_0 = 301,
            X_NEQ_0_DEC = 302,
            Y_EQ_0 = 303,
            Y_NEQ_0_DEC = 304,
            X_NEQ_Y = 305,
            PIN = 306,
            OSRE_NOTEMPTY = 307,
        }

        /// <summary>
        /// wait で使用する。
        /// </summary>
        public enum Operands4
        {
            GPIO = 400,
            PIN = Operands3.PIN,
            IRQ = 402,
        }

        /// <summary>
        /// push, pull で使用する。
        /// </summary>
        public enum Operands5
        {
            BLOCK = 500,
            NOBLOCK = 501,
        }

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
        public static void CodeStartSimple(
                string funcname,
                int smId,                  // state machine ID (will be used for IRQ rel)

                int inPins,
                int inNum,
                int outPins,
                int outNum,
                int sidesetPins,
                int sidesetNum,
                bool sidesetOpt
            )
        {
            NativeMethod.pio_code_start_simple(funcname, smId, inPins, inNum, outPins, outNum, sidesetPins, sidesetNum, sidesetOpt);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writeCode"></param>
        /// <param name="fileNameCode"></param>
        public static void CodeEnd(bool writeCode, string fileNameCode)
        {
            NativeMethod.pio_code_end(writeCode, fileNameCode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cycles"></param>
        /// <param name="fileNameIn"></param>
        /// <param name="fileNameOut"></param>
        public static void RunEmulation(int cycles, string fileNameIn, string fileNameOut)
        {
            NativeMethod.pio_run_emulation(cycles, fileNameIn, fileNameOut);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cond"></param>
        /// <param name="lbl"></param>
        /// <param name="sideset"></param>
        /// <param name="delay"></param>
        public static void Jmp(Operands3 cond, string lbl, int sideset, int delay)
        {
            NativeMethod.pio_jmp((int)cond, lbl, sideset, delay);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="polarity"></param>
        /// <param name="src"></param>
        /// <param name="index"></param>
        /// <param name="rel"></param>
        /// <param name="sideset"></param>
        /// <param name="delay"></param>
        public static void Wait(bool polarity, Operands4 src, int index, bool rel, int sideset, int delay)
        {
            NativeMethod.pio_wait(polarity, (int)src, index, rel, sideset, delay);
        }
    }
}
