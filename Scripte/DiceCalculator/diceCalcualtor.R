#code snippes

#Get number of possible fights as percent
#sum(as.numeric(mixTable[grepl("d", mixTable[,1]) |  grepl("m", mixTable[,1]),2]))

#Tim Alt
TimV1w1 = c('m','m','m','m','m','m','m','m','m',
       'a','a','a','a','a','a',
       'd','d','d','d',
       'b')

TimV1w2 = c('s','s','s','s','s','s','s','s','s',
       'a','a','a','a','a',
       'd','d','d','d','d','d')


#Tim2

DuellMonsterw1 = c(
            replicate(9, "d"),
            replicate(5, "a"),
            replicate(6, "s"))

DuellMonsterw2 = c(
            replicate(10, "m"),
            replicate(5, "a"),
            replicate(5, "s"))

Flo1 = c(
  replicate(8, "d"),
  replicate(5, "a"),
  replicate(7, "s"))

Flo2 = c(
  replicate(11, "m"),
  replicate(3, "a"),
  replicate(6, "s"))

#perfectdice

perfectdice = c(replicate(5, "m"),
                replicate(5, "a"),
                replicate(5, "d"),
                replicate(5, "s"))



the1 = c(replicate(10, "m"),
                replicate(10, "a"))


the2 = c(replicate(10, "d"),
                replicate(10, "s"))


#choose dice=

w1 = Flo1
w2 = Flo2





length(w1)
length(w2)

diceMatrix = matrix(NA,ncol=2,nrow=length(w1)^2)

diceSetNumber = 1

for (i in 1:length(w1)){
  
  diceMatrix[diceSetNumber:(diceSetNumber+length(w1)-1),1] = w1
  
  diceMatrix[diceSetNumber:(diceSetNumber+length(w1)-1),2] = w2[i]
  
  diceSetNumber = diceSetNumber + length(w1)   
  
}


sides = unique(c(w1,w2))

sidesMatrix = matrix(NA,ncol=2,nrow= sum(1:length(sides)))

sidesSetNumber = 1

for (i in 1:length(sides)){
  
  sidesMatrix[sidesSetNumber:(sidesSetNumber+(length(sides)-i)),1] = sides[i:length(sides)]
  
  sidesMatrix[sidesSetNumber:(sidesSetNumber+(length(sides)-i)),2] = sides[i]
  
  sidesSetNumber = sidesSetNumber + length(sides) +1 -i  
  
}


#Result matrix
#Name | Must | Can

RM = matrix(NA,ncol=2,nrow=dim(sidesMatrix)[1])

for (i in 1:dim(sidesMatrix)[1]){

combo1 = sum(diceMatrix[,1] == sidesMatrix[i,1] & diceMatrix[,2] == sidesMatrix[i,2])
combo2 = sum(diceMatrix[,1] == sidesMatrix[i,2] & diceMatrix[,2] == sidesMatrix[i,1])

if(sidesMatrix[i,1] == sidesMatrix[i,2]){
  comboCombined = max(combo1,combo2)
}else{
  comboCombined = combo1 + combo2
}

comboCombinedPrecent = comboCombined / length(w1)^2 * 100

RM[i,1] = paste(sidesMatrix[i,1],"-",sidesMatrix[i,2],sep = "")
RM[i,2] = comboCombinedPrecent

}

mixTable = RM[order(as.numeric(RM[,2])),]

#Solo matrix

SM = matrix(NA,ncol=3,nrow=length(sides))

for (i in 1:length(sides)){

solo1 = sum(diceMatrix[,1] == sides[i] & diceMatrix[,2] == sides[i])
solo2 = sum(diceMatrix[,1] == sides[i] | diceMatrix[,2] == sides[i])

Solo1CombinedPrecent = solo1 / length(w1)^2 * 100
Solo2CombinedPrecent = solo2 / length(w1)^2 * 100

SM[i,1] = sides[i]
SM[i,2] = Solo1CombinedPrecent
SM[i,3] = Solo2CombinedPrecent

}

SingleTable = SM[order(as.numeric(SM[,3])),]

colnames(mixTable) = c("name","%")

colnames(SingleTable) = c("name","Must","Can")

































