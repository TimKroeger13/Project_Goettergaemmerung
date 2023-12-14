#install.packages("stringr")
library(stringr)


roundTopointfive <- function(x) {
  return(floor(x) + round((x - floor(x)) * 2,digits = 0) / 2)
}

#create Matix

GewinnVerlustMatrix = matrix(NA,nrow = 10, ncol = 10)

colnames(GewinnVerlustMatrix) = str_split_1(toString(0:9), ", ")
rownames(GewinnVerlustMatrix)  =str_split_1(toString(0:-9), ", ")





for (gw in 0:9){
  for (vl in 0:9){
    
    #gw = 7
    #vl = 6
    
    baseCoefficent = 2/((10-gw)/20)
    
    gwChange = ((10-gw+vl)/20)
    gwCoefficent = gwChange * baseCoefficent
    gwValue = gwCoefficent / gwChange
    
    vlchange = 1-gwChange
    surplus = gwCoefficent-2
    vlValue =  surplus/vlchange
    vlCoefficent = vlValue * vlchange
    
    
    round((gwCoefficent - vlCoefficent),digits = 5) == 2
    
    GewinnVerlustMatrix[gw+1,vl+1] = paste(toString(roundTopointfive(gwValue)),"-",round(vlValue,digits = 2),sep = "")
    
    
    #cat("\nGewinn =",gwValue,"\nVerlust =",vlValue)
    
  }
}







paste(toString(roundTopointfive(gwValue)),"-",roundTopointfive(vlValue),sep = "")


write.csv(GewinnVerlustMatrix, "V:/Brettspiele/Timgammen_aktuell/Scripte/R/AkMatrix.csv")


















