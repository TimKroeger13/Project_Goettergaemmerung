H = 1/6
R = 1/6
S = 1/6
E = 2/6
Z = 1/12
A = 1/12

Cards = 28


cat("Helme = ",round(H*Cards,digits = 0),"\n",
    "Rüstung = ",round(R*Cards,digits = 0),"\n",
    "Schuhe = ",round(S*Cards,digits = 0),"\n",
    "Einhändig = ",round(E*Cards,digits = 0),"\n",
    "Zweihändig = ",round(Z*Cards,digits = 0),"\n",
    "Artefakte = ",round(A*Cards,digits = 0),"\n",
    sep="")






Wuerfe = 100000

dice = 3

Augen = 0

unter10 = 0

for (i in 1:Wuerfe){
  
  D20 = sample.int(20, dice, replace = TRUE)
  
  heighest = sort(D20,decreasing = TRUE)[1]
  
  if(heighest<10){
  
  unter10 = unter10+1
    
  }
  
  Augen = Augen + heighest
  
}

cat(Augen/Wuerfe)


cat(unter10/Wuerfe)

