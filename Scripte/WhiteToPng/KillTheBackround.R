### reset
rm(list = ls())
cat("\014")
#install.packages("png")
#install.packages("abind")
library(png)
library(abind)

importPath = "V:/Brettspiele/Project_Goettergaemmerung/Scripte/WhiteToPng/input/"
exportPath = "V:/Brettspiele/Project_Goettergaemmerung/Scripte/WhiteToPng/output/"


allrawCards = list.files(importPath)

for (i in 1:length(allrawCards)){
  
  ImportImage = readPNG(paste(importPath,allrawCards[i],sep=""))

  '
  transparentLayer = matrix(1, nrow = dim(ImportImage)[1], ncol = dim(ImportImage)[2])
  
  for (row in 1:dim(transparentLayer)[1]){
    
    for (colum in 1:dim(transparentLayer)[2]){
    
      transparentLayer[row,colum] = 1 - sum(ImportImage[row,colum,1:3])/3
      
    }
  }
  '
  
  transparentLayer = 1 - ((ImportImage[,,1] + ImportImage[,,2] + ImportImage[,,3]) / 3)
  
  if (dim(ImportImage)[3] == 4){
    
    ImportImage[,,4] = transparentLayer
    ImportImage[,,1] = 1
    ImportImage[,,2] = 1
    ImportImage[,,3] = 1
    TransImage = ImportImage
    
  }else{
    
    ImportImage[,,1] = 0
    ImportImage[,,2] = 0
    ImportImage[,,3] = 0
    TransImage = abind(ImportImage, transparentLayer, along = 3)
    
  }
  

  writePNG(TransImage,paste(exportPath,allrawCards[i],sep=""))
  
  print(paste(i, "/", length(allrawCards)))
  
  #Transparence is a value between 0 and 1.
  #o <- tranparent
  #1 <- NON transparent
  
  #for the other values
  #0 <- black
  #1 <- white
  
  
}








# png(paste(importPath,allrawCards[i],sep=""))

































