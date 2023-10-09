 <CsoundSynthesizer>
<CsOptions>
-o dac
</CsOptions>
<CsInstruments>

sr = 44100
ksmps = 32
nchnls = 2
0dbfs = 1

instr FM_vibr ;vibrato as the modulator is in the sub-audio range
kModFreq chnget "modFreq"
aModulator poscil 20, kModFreq
aCarrier poscil 0.5, 400 + aModulator
 out aCarrier, aCarrier
endin

</CsInstruments>
<CsScore>
f0 z
i "FM_vibr" 1 -1
</CsScore>
</CsoundSynthesizer>
