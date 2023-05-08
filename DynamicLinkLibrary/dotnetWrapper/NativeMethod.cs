using System.Runtime.InteropServices;

namespace DotnetWrapper
{
    /// <summary>
    /// DllImportをまとめたクラス
    /// </summary>
    class NativeMethod
    {
        const string dllName = "picopio_emu.dll";

        [DllImport(dllName, CharSet = CharSet.Ansi)]
        public static extern void pio_init([MarshalAs(UnmanagedType.U1)] bool out_gpio_bit_by_bit, [MarshalAs(UnmanagedType.U1)] bool in_gpio_bit_by_bit, [MarshalAs(UnmanagedType.U1)] bool disp_asm_stdout, [MarshalAs(UnmanagedType.U1)] bool distp_trace_stdout);

        [DllImport(dllName, CharSet = CharSet.Ansi)]
        public static extern void pio_code_start(
            string funcname,
            int sm_id,                  // state machine ID (for IRQ rel)

            int in_pins,
            int in_num,
            int out_pins,
            int out_num,
            int sideset_pins,
            int sideset_num,
            [MarshalAs(UnmanagedType.U1)] bool sideset_opt,

            [MarshalAs(UnmanagedType.U1)] bool isr_shift_right,       // SHIFTCTRL_IN_SHITDIR
            [MarshalAs(UnmanagedType.U1)] bool isr_autopush,
            int isr_autopush_threshold, // SHIFTCTRL_PUSH_THRESH
            [MarshalAs(UnmanagedType.U1)] bool osr_shift_right,       // SHIFTCTRL_OUT_SHIFTDIR
            [MarshalAs(UnmanagedType.U1)] bool osr_autopull,
            int osr_autopull_threshold, // SHIFTCTRL_PULL_THRESH
            int jmp_pin,                // EXECCTRL_JMP_PIN
            [MarshalAs(UnmanagedType.U1)] bool mov_status_sel,            // EXECCTRL_STATUS_SEL
            int mov_status_val          // EXECCTRL_STATUS_SEL
        );

        [DllImport(dllName, CharSet = CharSet.Ansi)]
        public static extern void pio_code_start_simple(
            string funcname,
            int sm_id,                  // state machine ID (will be used for IRQ rel)

            int in_pins,
            int in_num,
            int out_pins,
            int out_num,
            int sideset_pins,
            int sideset_num,
            [MarshalAs(UnmanagedType.U1)] bool sideset_opt
        );

        [DllImport(dllName, CharSet = CharSet.Ansi)]
        public static extern void pio_code_end([MarshalAs(UnmanagedType.U1)] bool write_code, string file_name_code);

        [DllImport(dllName, CharSet = CharSet.Ansi)]
        public static extern void pio_run_emulation(int cycles, string file_name_in, string file_name_out);

        ////////////////////////////
        // instructions
        ////////////////////////////
        [DllImport(dllName, CharSet = CharSet.Ansi)]
        public static extern void pio_jmp(int cond, string lbl, int sideset, int delay);
        [DllImport(dllName, CharSet = CharSet.Ansi)]
        public static extern void pio_wait([MarshalAs(UnmanagedType.U1)] bool polarity, int src, int index, [MarshalAs(UnmanagedType.U1)] bool rel, int sideset, int delay);
        [DllImport(dllName, CharSet = CharSet.Ansi)]
        public static extern void pio_in(int src, int bitcount, int sideset, int delay);
        [DllImport(dllName, CharSet = CharSet.Ansi)]
        public static extern void pio_out(int dest, int bitcount, int sideset, int delay);
        [DllImport(dllName, CharSet = CharSet.Ansi)]
        public static extern void pio_push([MarshalAs(UnmanagedType.U1)] bool iffull, [MarshalAs(UnmanagedType.U1)] bool block, int sideset, int delay);
        [DllImport(dllName, CharSet = CharSet.Ansi)]
        public static extern void pio_pull([MarshalAs(UnmanagedType.U1)] bool ifempty, [MarshalAs(UnmanagedType.U1)] bool block, int sideset, int delay);
        [DllImport(dllName, CharSet = CharSet.Ansi)]
        public static extern void pio_mov(int dest, int op, int src, int sideset, int delay);
        [DllImport(dllName, CharSet = CharSet.Ansi)]
        public static extern void pio_irq([MarshalAs(UnmanagedType.U1)] bool clr, [MarshalAs(UnmanagedType.U1)] bool wait, int index, [MarshalAs(UnmanagedType.U1)] bool rel, int sideset, int delay);
        [DllImport(dllName, CharSet = CharSet.Ansi)]
        public static extern void pio_set(int dest, int data, int sideset, int delay);

        // (pseudo instructions)
        [DllImport(dllName, CharSet = CharSet.Ansi)]
        public static extern void pio_comment(string comment);       // max len = MAX_COMMENT_LEN
        [DllImport(dllName, CharSet = CharSet.Ansi)]
        public static extern void pio_label(string lbl);
        [DllImport(dllName, CharSet = CharSet.Ansi)]
        public static extern void pio_nop(int sideset, int delay);
        [DllImport(dllName, CharSet = CharSet.Ansi)]
        public static extern void pio_wrap_target();
        [DllImport(dllName, CharSet = CharSet.Ansi)]
        public static extern void pio_wrap();
        [DllImport(dllName, CharSet = CharSet.Ansi)]
        public static extern void pio_origin(int addr);

    }
}
