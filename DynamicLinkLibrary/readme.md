# DynamicLinkLibrary
ヘッダファイルに記述されている関数をDLL化するプロジェクト。C言語以外で使用するためのものです。関連するヘッダファイルは無いので、これをC/C++で使用することはできません。オリジナルのヘッダファイルを使ってください。

# dotnetWrapper
主に、C#で使用するためのラッパーライブラリ。

## 使い方
名前空間は `PicopioEmu` です。

`Emulator` クラスの静的関数として、`picopio_emu.h` の関数がそのまま実装されています。
`define` パラメータは、`Init` 関数で指定できます。`main` 関数の最初に記述してください。

実行ファイルと同じフォルダに、`picopio_emu.dll` と `PicopioEmuDotnet.dll` を置いておく必要があります。

`PIO_UNUSE` は `Emulator.UNUSE` として定義されています。他のdefine定数は、列挙型として定義されています。

# sample
dotnetWrapperを使うサンプルプロジェクトです。これは、`Program` クラスに `Emulator` クラスを継承させているので、`Emulator.` を省略して直接関数名を記述しています。例えば、`Emulator.Nop` は `Nop` と書くことができます。
