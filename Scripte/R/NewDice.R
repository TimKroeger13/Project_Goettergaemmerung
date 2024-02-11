#d1 = c('m','m','m','m','m','m','m','m','m','m','a','a','a','a','a','a','a','a','a','a')
#d2 = c('d','d','d','d','d','d','d','d','d','d','s','s','s','s','s','s','s','s','s','s')
#d3 = c('b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b','b')


d1 = c('m','m','m','m','m','m',
       'a','a','a','a','a',
       'd','d','d','d','d','d','d','d','d')

d2 = c('s','s','s','s','s','s','s','s','s','s',
       'm','m','m','m','m','m',
       'a','a','a','a')


d3 = c('b','b','b','b','b','b','b','b','b','b',
       'b','b','b','b','b','b','b','b','b','b')



"
d1 = c('m','m','m','m','m','m','m','m','m','m',
       'a','a','a','a','a','a','a','a',
       'd','d')

d2 = c('m','m',
       'a',
       'd','d','d','d','d','d','d','d','d',
       'b','b','b','b','b','b','b','b')

d3 = c('s','s','s','s','s','s','s','s','s','s',
       'm','m',
       'd','d',
       'a',
       'b','b','b','b','b')
       "

#3,2,1 => b,m,a
#1,2,3 => b, m, a


# Create all combinations

d1_u = unique(d1)

d2_u = unique(d2)

d3_u = unique(d3)

CombinationLength = length(d1_u) * length(d2_u) * length(d3_u)

#Add variables

## Dice 1

var_d1 = rep(sort(d1_u), times=1 ,
             each = CombinationLength / length(d1_u))

## Dice 2

var_d2 = rep(sort(d2_u), times= (CombinationLength / length(d1_u) * length(d1_u)) / (length(d2_u) * (CombinationLength / length(d1_u)) /  length(d2_u)),
             each = (CombinationLength / length(d1_u)) /  length(d2_u))

## Dice 3

var_d3 = rep(sort(d3_u), times = CombinationLength / length(d3_u),each = 1)

#Create new sorted combined matrix out of all possibilities

TestForMutipleVector = NULL

for (i in 1:CombinationLength){
  
  TestForMutipleVector = c(TestForMutipleVector,paste(sort(c(var_d1[i],var_d2[i],var_d3[i])),collapse=""))
  
}

LongConbinationVector = unique(TestForMutipleVector)

ShortConbinationVector = NULL

for (i in 1:length(LongConbinationVector)){
  
  ShortConbinationVector = c(ShortConbinationVector,gsub("b", "",paste(unique(strsplit(LongConbinationVector[i],"")[[1]]),collapse="")))
  
}

NameLookUpTable = cbind(LongConbinationVector,ShortConbinationVector)


gsub("b", "",paste(unique(strsplit(LongConbinationVector[i],"")[[1]]),collapse=""))

#Count occurrences

OccurrenceVector = matrix(0, nrow = length(LongConbinationVector), ncol = 1)
rownames(OccurrenceVector) = LongConbinationVector

for (one in 1:20){
  for (two in 1:20){
    for (three in 1:20){
      
      CurrentDice = paste(sort(c(d1[one],d2[two],d3[three])),collapse="")
      
      OccurrenceVector[which(rownames(OccurrenceVector) == CurrentDice),1] =
        OccurrenceVector[which(rownames(OccurrenceVector) == CurrentDice),1] + 1
        
    }
  }
}

#Create Short Matrix

ShortConbinationVector_unique = unique(ShortConbinationVector)

OrderedShortConbinationVector_unique = ShortConbinationVector_unique[order(nchar(ShortConbinationVector_unique),ShortConbinationVector_unique)]

FinalList = matrix(0, nrow = length(OrderedShortConbinationVector_unique), ncol = 2)
row.names(FinalList) = OrderedShortConbinationVector_unique

for (k in 1 : length(OccurrenceVector)){
  
  ProjectedPostion = which(row.names(FinalList) == NameLookUpTable[which(row.names(OccurrenceVector)[k] == NameLookUpTable[,1]),2])
  
  FinalList[ProjectedPostion,1] =
    FinalList[ProjectedPostion,1] + OccurrenceVector[k]
  
}

FinalList[,2] = FinalList[,1] / 80


#Total occurrence

TotalOccurenceMatrix = matrix(NA, nrow = 4, ncol = 2)
row.names(TotalOccurenceMatrix) = c('m','a','d','s')

for (check in 1:length(row.names(TotalOccurenceMatrix))){
  
  Type = row.names(TotalOccurenceMatrix)[check]
  
  TotalOccurenceMatrix[check,1] = sum(FinalList[grepl(Type, row.names(FinalList), fixed = TRUE),1])
  
}

TotalOccurenceMatrix[,2] = TotalOccurenceMatrix[,1] / 80

























