

###


Faktor = 2.8
Base = 1.4
Length = 31





diff =  Base - log(Faktor)*Faktor

out = matrix(NA, nrow = Length-2, ncol = 2)

for (i in 3:Length){
  
  out[(i-2),2] = round(log(i)*Faktor + diff,digits = 1)
  
}

out[,1] = seq(from = 3, to = Length, by =1)

print(out)





verteilung = c(12,16,4,7,7,3,5,9,6,8,31,11,10,30,4,5,14,20,21,3,16,7,8,14,22)

plot(sort(verteilung))



#D20 stats

numbers = NULL

for (i in 1:10000){

  numbers = c(numbers,max(sample.int(20, size = 2, replace = TRUE)))

}

hist(numbers,breaks=24)

#print(mean(numbers))




numbers = NULL

for (i in 1:10000){
  
  numbers = c(numbers,max(sample.int(20, size =10, replace = TRUE)))
  
}

hist(numbers,breaks=20)

#install.packages("ggplot2") 
library("ggplot2")

ggplot(as.data.frame(numbers), aes(numbers)) +            # ggplot2 histogram with default bins
  geom_histogram(bins = 20,binwidth = 0.5)


print(sum(numbers <= 6) / 10000 * 100)

7480 / 10000



### Presentation

#Get all versions of a dice



Dice = 6
numberOfDice = 2

GetDice = function(Dice, numberOfDice) {
  
  diceMatrix = matrix(NA, nrow = Dice^numberOfDice, ncol = numberOfDice)
  
  DiceNumbers = 1:Dice
  
  for (order in 1:numberOfDice){
    
    DiceSquenceLenght = Dice^(order-1)
    
    SquenceCounter = 1
    
    LoopTracker = 1
    
    for(k in 1:Dice^numberOfDice){
      
      if(LoopTracker > DiceSquenceLenght){
        
        SquenceCounter = SquenceCounter+1
        LoopTracker = 1
        
        if(SquenceCounter > Dice){
          
          SquenceCounter = SquenceCounter - Dice
          
        }
        
      }
      
      diceMatrix[k,order] = DiceNumbers[SquenceCounter]
      
      LoopTracker = LoopTracker+1
      
    }
  }
  
  return(diceMatrix)
  
}



GetMax = function(DiceMatrix){
  
  OutPutMatrix = matrix(NA,nrow = dim(DiceMatrix)[1], ncol = 1)
  
  for(i in 1:dim(DiceMatrix)[1]){
  
    OutPutMatrix[i,1] = max(DiceMatrix[i,])
  
  }
  
  return(OutPutMatrix)
}








install.packages("ggplot2")
library(ggplot2)



CDiceMatrix = GetDice(6,2)

SummedDice = CDiceMatrix[,1] + CDiceMatrix[,2]



ggplot(as.data.frame(SummedDice), aes(SummedDice)) +    
  geom_histogram(bins = 6,binwidth = 0.5)












D6_1 = GetDice(6,1)
D8_1 = GetDice(8,1)
D12_1 = GetDice(12,1)
D20_1 = GetDice(20,1)
D20_2_sum = matrix(GetDice(20,2)[,1] + GetDice(20,2)[,2], ncol = 1)
D20_2 = GetMax(GetDice(20,2))
D20_3 = GetMax(GetDice(20,3))
D20_4 = GetMax(GetDice(20,4))

D12_2 = GetMax(GetDice(12,2))
D12_3 = GetMax(GetDice(12,3))
D12_4 = GetMax(GetDice(12,4))



ggplot(as.data.frame(D6_1), aes(D6_1)) +    
  geom_histogram(bins = 6,binwidth = 0.5)

ggplot(as.data.frame(D8_1), aes(D8_1)) +    
  geom_histogram(bins = 8,binwidth = 0.5)

ggplot(as.data.frame(D12_1), aes(D12_1)) +    
  geom_histogram(bins = 12,binwidth = 0.5)

ggplot(as.data.frame(D20_1), aes(D20_1)) +    
  geom_histogram(bins = 20,binwidth = 0.5)

ggplot(as.data.frame(D20_2_sum), aes(D20_2_sum)) +    
  geom_histogram(bins = 20,binwidth = 0.5)

ggplot(as.data.frame(D20_2), aes(D20_2)) +    
  geom_histogram(bins = 20,binwidth = 0.5)

ggplot(as.data.frame(D20_3), aes(D20_3)) +    
  geom_histogram(bins = 20,binwidth = 0.5)

ggplot(as.data.frame(D20_4), aes(D20_4)) +    
  geom_histogram(bins = 20,binwidth = 0.5)


cat("D6",mean(D6_1))
cat("D8",mean(D8_1))
cat("D12",mean(D12_1))
cat("D20",mean(D20_1))
cat("2xD20",mean(D20_2))
cat("3xD20",mean(D20_3))
cat("4xD20",mean(D20_4))


cat("Crit+1 = +",mean(D8_1)-mean(D6_1)," / 0",sep="")
cat("Crit+2 = +",mean(D12_1)-mean(D8_1)," / 0",sep="")
cat("Crit+3 = +",mean(D20_1)-mean(D12_1)," / 0",sep="")
cat("Crit+4 = +",mean(D20_2)-mean(D20_1)," / 0",sep="")
cat("Crit+5 = +",mean(D20_3)-mean(D20_2)," / 0",sep="")
cat("Crit+6 = +",mean(D20_4)-mean(D20_3)," / 0",sep="")

barplot(c(mean(D8_1)-mean(D6_1),
          mean(D12_1)-mean(D8_1),
          mean(D20_1)-mean(D12_1),
          mean(D20_2)-mean(D20_1),
          mean(D20_3)-mean(D20_2),
          mean(D20_4)-mean(D20_3)),
        names.arg = c("D8","D12","D20","2xD20","3xD20","4xD20"))

# the end of the old story

#self indicated
sum(mean(D6_1) < D6_1) / length(D6_1) *100

sum(mean(D6_1) < D8_1) / length(D8_1) *100

#normal case
(sum(mean(D6_1) < D8_1) / length(D8_1) *100) -50

(sum(mean(D8_1) < D12_1) / length(D12_1) *100) -50

(sum(mean(D12_1) < D20_1) / length(D20_1) *100) -50

(sum(mean(D20_1) < D20_2) / length(D20_2) *100) -50

(sum(mean(D20_2) < D20_3) / length(D20_3) *100) -50

(sum(mean(D20_3) < D20_4) / length(D20_4) *100) -50

barplot(c((sum(mean(D6_1) < D8_1) / length(D8_1) *100) -50,
          (sum(mean(D8_1) < D12_1) / length(D12_1) *100) -50,
          (sum(mean(D12_1) < D20_1) / length(D20_1) *100) -50,
          (sum(mean(D20_1) < D20_2) / length(D20_2) *100) -50,
          (sum(mean(D20_2) < D20_3) / length(D20_3) *100) -50,
          (sum(mean(D20_3) < D20_4) / length(D20_4) *100) -50),
        names.arg = c("D8","D12","D20","2xD20","3xD20","4xD20"))


#boxplot

boxplot(D6_1,ylim=c(1 , 20),main="D6_1")
boxplot(D8_1,ylim=c(1 , 20),main="D8_1")
boxplot(D12_1,ylim=c(1 , 20),main="D12_1")
boxplot(D20_1,ylim=c(1 , 20),main="D20_1")
boxplot(D20_2,ylim=c(1 , 20),main="D20_2")
boxplot(D20_3,ylim=c(1 , 20),main="D20_3")
boxplot(D20_4,ylim=c(1 , 20),main="D20_4")




#with strength - quatile bases






D6_1_Q = c(t.test(D6_1)[[4]][1],t.test(D6_1)[[4]][2])
D8_1_Q = c(t.test(D8_1)[[4]][1],t.test(D8_1)[[4]][2])
D12_1_Q = c(t.test(D12_1)[[4]][1],t.test(D12_1)[[4]][2])
D20_1_Q = c(t.test(D20_1)[[4]][1],t.test(D20_1)[[4]][2])
D20_2_Q = c(t.test(D20_2)[[4]][1],t.test(D20_2)[[4]][2])
D20_3_Q = c(t.test(D20_3)[[4]][1],t.test(D20_3)[[4]][2])
D20_4_Q = c(t.test(D20_4)[[4]][1],t.test(D20_4)[[4]][2])


cat("D6",mean(D6_1_Q))
cat("D8",mean(D8_1_Q))
cat("D12",mean(D12_1_Q))
cat("D20",mean(D20_1_Q))
cat("2xD20",mean(D20_2_Q))
cat("3xD20",mean(D20_3_Q))
cat("4xD20",mean(D20_4_Q))

cat("Crit+1 = +",mean(D8_1_Q)-mean(D6_1_Q)," / 0",sep="")
cat("Crit+2 = +",mean(D12_1_Q)-mean(D8_1_Q)," / 0",sep="")
cat("Crit+3 = +",mean(D20_1_Q)-mean(D12_1_Q)," / 0",sep="")
cat("Crit+4 = +",mean(D20_2_Q)-mean(D20_1_Q)," / 0",sep="")
cat("Crit+5 = +",mean(D20_3_Q)-mean(D20_2_Q)," / 0",sep="")
cat("Crit+6 = +",mean(D20_4_Q)-mean(D20_3_Q)," / 0",sep="")


barplot(c(mean(D8_1_Q)-mean(D6_1_Q),
          mean(D12_1_Q)-mean(D8_1_Q),
          mean(D20_1_Q)-mean(D12_1_Q),
          mean(D20_2_Q)-mean(D20_1_Q),
          mean(D20_3_Q)-mean(D20_2_Q),
          mean(D20_4_Q)-mean(D20_3_Q)),
        names.arg = c("D8","D12","D20","2xD20","3xD20","4xD20"))




cat("Crit+1 \nGet = +",mean(D8_1_Q)-mean(D6_1_Q)," / 0",sep="")
cat("Crit+2 \nGet = +",mean(D12_1_Q)-mean(D8_1_Q)+mean(D8_1_Q)-mean(D6_1_Q)," / 0",sep="")
cat("Crit+3 \nGet = +",mean(D20_1_Q)-mean(D12_1_Q)+mean(D12_1_Q)-mean(D8_1_Q)+mean(D8_1_Q)-mean(D6_1_Q)," / 0",sep="")
cat("Crit+4 \nGet = +",mean(D20_2_Q)-mean(D20_1_Q)+mean(D20_1_Q)-mean(D12_1_Q)+mean(D12_1_Q)-mean(D8_1_Q)+mean(D8_1_Q)-mean(D6_1_Q)," / 0",sep="")
cat("Crit+5 \nGet = +",mean(D20_3_Q)-mean(D20_2_Q)+mean(D20_2_Q)-mean(D20_1_Q)+mean(D20_1_Q)-mean(D12_1_Q)+mean(D12_1_Q)-mean(D8_1_Q)+mean(D8_1_Q)-mean(D6_1_Q)," / 0",sep="")
cat("Crit+6 \nGet = +",mean(D20_4_Q)-mean(D20_3_Q)+mean(D20_3_Q)-mean(D20_2_Q)+mean(D20_2_Q)-mean(D20_1_Q)+mean(D20_1_Q)-mean(D12_1_Q)+mean(D12_1_Q)-mean(D8_1_Q)+mean(D8_1_Q)-mean(D6_1_Q)," / 0",sep="")





################################################################################
### With multiple D12
################################################################################

cat("D6",mean(D6_1))
cat("D8",mean(D8_1))
cat("D12",mean(D12_1))
cat("2xD12",mean(D12_2))
cat("3xD12",mean(D12_3))
cat("4xD12",mean(D12_4))




cat("Crit+1 = +",mean(D8_1)-mean(D6_1)," / 0",sep="")
cat("Crit+2 = +",mean(D12_1)-mean(D8_1)," / 0",sep="")
cat("Crit+3 = +",mean(D12_2)-mean(D12_1)," / 0",sep="")
cat("Crit+4 = +",mean(D12_3)-mean(D12_2)," / 0",sep="")
cat("Crit+5 = +",mean(D12_4)-mean(D12_3)," / 0",sep="")

barplot(c(mean(D8_1)-mean(D6_1),
          mean(D12_1)-mean(D8_1),
          mean(D12_2)-mean(D12_1),
          mean(D12_3)-mean(D12_2),
          mean(D12_4)-mean(D12_3)),
        names.arg = c("D8","D12","2xD12","3xD12","4xD12"))

#better Rolles

boxplot(D6_1,ylim=c(1 , 12),main="D6_1")
boxplot(D8_1,ylim=c(1 , 12),main="D8_1")
boxplot(D12_1,ylim=c(1 , 12),main="D12_1")
boxplot(D12_2,ylim=c(1 , 12),main="D12_2")
boxplot(D12_3,ylim=c(1 , 12),main="D12_3")
boxplot(D12_4,ylim=c(1 , 12),main="D12_4")

barplot(c((sum(mean(D6_1) < D8_1) / length(D8_1) *100) -50,
          (sum(mean(D8_1) < D12_1) / length(D12_1) *100) -50,
          (sum(mean(D12_1) < D12_2) / length(D12_2) *100) -50,
          (sum(mean(D12_2) < D12_3) / length(D12_3) *100) -50,
          (sum(mean(D12_3) < D12_4) / length(D12_4) *100) -50),
        names.arg = c("D8","D12","2xD12","3xD12","4xD12"))


#Kosts

cat("Crit+1 = +",mean(D8_1)-mean(D6_1)," / 0",sep="")
cat("Crit+2 = +",mean(D12_1)-mean(D8_1)+mean(D8_1)-mean(D6_1)," / 0",sep="")
cat("Crit+3 = +",mean(D12_2)-mean(D12_1)+mean(D12_1)-mean(D8_1)+mean(D8_1)-mean(D6_1)," / 0",sep="")
cat("Crit+4 = +",mean(D12_3)-mean(D12_2)+mean(D12_2)-mean(D12_1)+mean(D12_1)-mean(D8_1)+mean(D8_1)-mean(D6_1)," / 0",sep="")
cat("Crit+5 = +",mean(D12_4)-mean(D12_3)+mean(D12_3)-mean(D12_2)+mean(D12_2)-mean(D12_1)+mean(D12_1)-mean(D8_1)+mean(D8_1)-mean(D6_1)," / 0",sep="")























