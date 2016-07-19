cp ..\basic_dsp\target\release\basic_dsp.dll .\BasicDsp\RustDrop\basic_dsp.dll
if (Test-Path BasicDsp\bin) {
    rm -r BasicDsp\bin
}
if (Test-Path BasicDsp\obj) {
    rm -r BasicDsp\obj
}
msbuild /p:Configuration=Release /p:Platform=x64 /t:clean
msbuild /p:Configuration=Release /p:Platform=x64 /t:rebuild