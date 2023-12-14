

MutateDice = function(dice,fields,MutationNumber,DiceSize) {
  
  DiceNew = sample(0:fields, MutationNumber, replace=T)
  
  dicePostions = sample(1:DiceSize, MutationNumber, replace=T)
  
  for (i in 1:length(DiceNew)){
    
    if(DiceNew[i] != 0){
      
      dice[dicePostions[i]] = DiceNew[i]

    }
  }
  
  return(dice)
  
}

GetDistributionDoubleDice = function(dice,fields,oneisBlank){
  
  d1 = dice[1:20]
  d2 = dice[21:40]
  
  d1_long = NULL
  d2_long = NULL
  
  DiceChanges = rep(0, fields*2)  
  
  for (i in 1:20){
    
    d1_long = c(d1_long,rep(d1[i], 20))
    d2_long = c(d2_long,d2)
    
  }
  
  #can Loop
  for (d in 1:fields){
    
   DiceChanges[d] = sum(d1_long==d  | d2_long==d)
    
  }
  
  #Must loop
  for (d in 1:fields){
    
    DiceChanges[d+5] = sum(d1_long == d2_long & (d1_long==d  & d2_long==d))
    
    if(oneisBlank){
      
      DiceChanges[d+5] = DiceChanges[d+5] + sum((d1_long==d  & d2_long==1) | (d1_long==1  & d2_long==d))
      
    }
    
  }
  
  return(DiceChanges / 4)
}




CreatePopulation = function(partendice,fields,population,MutationNumber,DiceSize,oneisBlank){

  diceDomograic = matrix(NA, nrow = population, ncol = fields*2)
  DistList = list()

  for (i in 1:population){
    
    childDice = MutateDice(partendice,fields, MutationNumber, DiceSize)
    
    DistList[[i]] = childDice
    
    diceDomograic[i,] = GetDistributionDoubleDice(dice = childDice,fields,oneisBlank)
    
  }
  
  
  DistList[["diceDomograic"]] = diceDomograic

  return(DistList)

}



Condition_FixPercentage = function(generation,percent,objective){
  
 EmptyLossList = rep(0, dim(generation[["diceDomograic"]])[1])

  return(EmptyLossList + abs(generation[["diceDomograic"]][,objective] - percent))
}


Condition_InbetweenPercentage = function(generation,lowerPercent,upperPercent,objective){
  
  EmptyLossList = rep(0, dim(generation[["diceDomograic"]])[1])
  
  lowerCon = generation[["diceDomograic"]][,objective] - lowerPercent
  upperCon = upperPercent -generation[["diceDomograic"]][,objective]
  
  lowerCon[lowerCon>0] = 0
  upperCon[upperCon>0] = 0
  
  return(EmptyLossList + abs(pmin(lowerCon,upperCon)))
  
}

Condition_MustOccureFixPercent = function(generation,percent,objective){
  
  EmptyLossList = rep(0, dim(generation[["diceDomograic"]])[1])

  return(EmptyLossList + abs(generation[["diceDomograic"]][,objective+dim(generation[["diceDomograic"]])[2]/2] - percent))
  
}




Condition_FixPercentage2conditions = function(generation,percent,objective1,objective2){
  
  EmptyLossList = rep(0, dim(generation[["diceDomograic"]])[1])
  
  return(EmptyLossList + abs((generation[["diceDomograic"]][,objective1] + generation[["diceDomograic"]][,objective2]) - percent))
}


Condition_InbetweenPercentage2conditions = function(generation,lowerPercent,upperPercent,objective1,objective2){
  
  EmptyLossList = rep(0, dim(generation[["diceDomograic"]])[1])
  
  lowerCon = (generation[["diceDomograic"]][,objective1]+generation[["diceDomograic"]][,objective2]) - lowerPercent
  upperCon = upperPercent - (generation[["diceDomograic"]][,objective1]+generation[["diceDomograic"]][,objective2])
  
  lowerCon[lowerCon>0] = 0
  upperCon[upperCon>0] = 0
  
  return(EmptyLossList + abs(pmin(lowerCon,upperCon)))
  
}


Condition_IsOppositeTo = function(generation,objective1,objective2){
  
  EmptyLossList = rep(0, dim(generation[["diceDomograic"]])[1])
  
  for (i in 1:dim(generation[["diceDomograic"]])[1]){
    
    EmptyLossList[i] = abs(sum(generation[[i]][1:20] == objective1) - sum(generation[[i]][21:40] == objective2)) + 
    abs(sum(generation[[i]][21:40] == objective1) - sum(generation[[i]][1:20] == objective2))
    
  }

  return(EmptyLossList)
}


Condition_minimiseZeros = function(generation){
  
  EmptyLossList = rep(0, dim(generation[["diceDomograic"]])[1])
  
  for (i in 1:dim(generation[["diceDomograic"]])[1]){
    
    EmptyLossList[i] = sum(generation[[i]] == 0) * 10000
  }
  
  return(EmptyLossList)
}



#Is opposite
#Is not opposite
#must occure x percent









#rbind(DiceChanges,DiceChanges)




Blank = 1
Monster = 2
Duell = 3
Spell = 4
Quest = 5











#Condition_FixPercentage
#Condition_InbetweenPercentage
#Condition_MustOccureFixPercent
#Condition_FixPercentage2conditions
#Condition_InbetweenPercentage2conditions
#Condition_IsOppositeTo


#For loop
ParentDice = rep(0, 40)
population = 1000
fields = 5
MutationNumber = 10
DiceSize = 40
oneisBlank = TRUE

Blank = 1
Monster = 2
Duell = 3
Spell = 4
Quest = 5

counter = 0
BestLoss = Inf

while (TRUE) {
  
  lossList = rep(0,population)  
  
  generation = CreatePopulation(ParentDice,fields,population,MutationNumber,DiceSize,oneisBlank)
  
  #Conditions
  
  #1 Monster + Duell <66%
  #2 Monster + Duell >40%
  #3 Duell = 30-50%
  #4 Quest >30 - 50%
  #5 Spell >40 - 60
  
  #6 Monster = 45%
  
  #7 Quest oppsite to Monster
  
  #8 Quest must 7%
  #9 Blankmust = 0%
  #10 Monster Must = 5%
  
  
  #1 Monster 45-55%
  #2 Duell 35%
  #3 Zauberkarte opposing Zauber
  #4 Aktion oppsign aktion
  
  
  
  
  
  #1
  lossList = lossList + Condition_FixPercentage(generation = generation,percent = 100,objective = Monster)
  
  lossList = lossList + Condition_FixPercentage(generation = generation,percent = 100,objective = Duell)
  
  #2
  #lossList = lossList + Condition_FixPercentage(generation = generation,
  #                                              percent = 35,
  #                                             objective = Duell)
  
  #3
  #lossList = lossList + Condition_IsOppositeTo(generation = generation, objective1 = Spell, objective2 = Spell)
  
  #4
  #lossList = lossList + Condition_IsOppositeTo(generation = generation, objective1 = Quest, objective2 = Quest)
  
  #lossList = lossList + Condition_MustOccureFixPercent(generation = generation,
   #                                                    percent = 0,
   #                                                    objective = Blank)
  
  #lossList = lossList + Condition_minimiseZeros(generation = generation)
  
  
  
  "
  #1,2
  lossList = lossList + Condition_InbetweenPercentage2conditions(generation = generation,
                                                                 lowerPercent = 40,
                                                                 upperPercent = 66,
                                                                 objective1 = Monster,
                                                                 objective2 = Duell)
  
  
  #3
  lossList = lossList + Condition_InbetweenPercentage(generation = generation,
                                                      lowerPercent = 30,
                                                      upperPercent = 50,
                                                      objective = Duell)
  
  #4
  lossList = lossList + Condition_InbetweenPercentage(generation = generation,
                                                      lowerPercent = 30,
                                                      upperPercent = 50,
                                                      objective = Quest)
  
  #5
  lossList = lossList + Condition_InbetweenPercentage(generation = generation,
                                                      lowerPercent = 40,
                                                      upperPercent = 60,
                                                      objective = Spell)
  
  #6
  lossList = lossList + Condition_FixPercentage(generation = generation,
                                                percent = 47,
                                                objective = Monster)
  
  #7
  lossList = lossList + Condition_IsOppositeTo(generation = generation,
                                               objective1 = Monster,
                                               objective2 = Quest)
  
  
  #8
  lossList = lossList + Condition_MustOccureFixPercent(generation = generation,
                                                       percent = 7,
                                                       objective = Quest)
  
  #9
  lossList = lossList + Condition_MustOccureFixPercent(generation = generation,
                                                       percent = 0,
                                                       objective = Blank)
  
  #11
  lossList = lossList + Condition_MustOccureFixPercent(generation = generation,
                                                       percent = 5,
                                                       objective = Monster)
  
  #11
  lossList = lossList + Condition_minimiseZeros(generation = generation)
  
 "
  
  
  
  
  
  
  
  #print(min(lossList))
  if (min(lossList) < BestLoss){
    
    ParentDice = generation[[order(lossList)[1]]]
    
    BestLoss = min(lossList)
    
    cat("Current best loss:",BestLoss,"\n")
    
    counter = 0
    
  }else{
    
    counter = counter+1
    
    if(counter >= 100){
      
      cat("Dice converged!")
      break
      
    }
    
  }
}







ParentDice[ParentDice == 1] = "Blank"
ParentDice[ParentDice == 2] = "Monster"
ParentDice[ParentDice == 3] = "Duell"
ParentDice[ParentDice == 4] = "Spell"
ParentDice[ParentDice == 5] = "Aktion"

#Blank = 1
#Monster = 2
#Duell = 3
#Spell = 4
#Quest = 5

sort(ParentDice[1:20])

sort(ParentDice[21:40])









