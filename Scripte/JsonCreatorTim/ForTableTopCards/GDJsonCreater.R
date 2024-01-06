#For Tabletop

pathOfTheCards = "V:/Brettspiele/Timgammen_aktuell/Karten/Cards_V1_05_00/"
SavePathOfTheJsons = "V:/Brettspiele/Project_Goettergaemmerung/Scripte/JsonCreatorTim/ForTableTopCards/Json/"
  
#UrlFronts = "https://www.user.tu-berlin.de/timkroeger/TableTop/Cards/AllCards/"
#UrlBacks = "https://www.user.tu-berlin.de/timkroeger/TableTop/Cards/Backs/"

UrlFronts = "https://www.user.tu-berlin.de/timkroeger/TableTop/Test_V2_05_00/AllCards/"
UrlBacks = "https://www.user.tu-berlin.de/timkroeger/TableTop/Test_V2_05_00/Backs/"

#UrlFronts = "V:/Brettspiele/Timgammen_aktuell/Karten/V_6/"
#UrlBacks = "V:/Brettspiele/Timgammen_aktuell/Kartenrücken/TableTop/"

#Script
setwd(pathOfTheCards)

list.dirs(path = getwd(), full.names = TRUE, recursive = TRUE)

filenames = list.files(getwd())

AllJsonFiles = list()

#split into extra deck for no Extra deck

extraDeckMask = substring(filenames, 9, 9) == "E" & substring(filenames, 0, 3) != "sbl"

AllJsonFiles[["ext"]] = filenames[extraDeckMask]

#Normal Card distinct decks

deckSplits= unique(substring(filenames[!extraDeckMask], 1, 3))
AlldeckSplits = substring(filenames[!extraDeckMask], 1, 3)

for (i in 1:length(deckSplits)){
  
  AllJsonFiles[[deckSplits[i]]] = filenames[!extraDeckMask][deckSplits[i] == AlldeckSplits]
  
}

length(AllJsonFiles)


#Create Jsons

GetJson <- function(UrlFronts,UrlBacks,cardnames) {
  
  #header
  
  DeackHeader = '{
  "SaveName": "",
  "Date": "",
  "VersionNumber": "",
  "GameMode": "",
  "GameType": "",
  "GameComplexity": "",
  "Tags": [],
  "Gravity": 0.5,
  "PlayArea": 0.5,
  "Table": "",
  "Sky": "",
  "Note": "",
  "TabStates": {},
  "LuaScript": "",
  "LuaScriptState": "",
  "XmlUI": "",
  "ObjectStates": [
    {
      "GUID": "",
      "Name": "Deck",
      "Transform": {
        "posX": 0,
        "posY": 0,
        "posZ": 0,
        "rotX": 0,
        "rotY": 0,
        "rotZ": 0,
        "scaleX": 1.0,
        "scaleY": 1.0,
        "scaleZ": 1.0
      },
      "Nickname": "",
      "Description": "",
      "GMNotes": "",
      "AltLookAngle": {
        "x": 0.0,
        "y": 0.0,
        "z": 0.0
      },
      "ColorDiffuse": {
        "r": 0.713235259,
        "g": 0.713235259,
        "b": 0.713235259
      },
      "LayoutGroupSortIndex": 0,
      "Value": 0,
      "Locked": false,
      "Grid": true,
      "Snap": true,
      "IgnoreFoW": false,
      "MeasureMovement": false,
      "DragSelectable": true,
      "Autoraise": true,
      "Sticky": true,
      "Tooltip": true,
      "GridProjection": false,
      "HideWhenFaceDown": true,
      "Hands": false,
      "SidewaysCard": false,'
  
  #ChardIds
  
  CardBigIds = seq(from = 1, to = length(cardnames[[1]]))*100
  
  deckId = "\n      \"DeckIDs\": ["
  
  for(i in 1:length(cardnames[[1]])){
    
    deckId = paste(deckId,"\n        ",CardBigIds[i],",",sep = "")
  }
  
  deckId = substring(deckId, 1, (nchar(deckId)-1))
  
  deckIdsEnd = "\n      ],\n     "
  
  deckId = paste(deckId,deckIdsEnd,sep = "")
  
  ###DeckPictures
  
  deckPicHeader = '"CustomDeck": {
'
  
  for(i in 1:length(cardnames[[1]])){
    
    #deckPicMain = paste('\n        \"',i,'\": {\n      \"FaceURL\": \"',UrlFronts,cardnames[[1]][[i]],'\",\n      \"BackURL\": \"',UrlBacks,substring(cardnames[[1]][[i]], 1, 3),'.png\",\n      \"NumWidth\": 1,\n      \"NumHeight\": 1,\n      \"BackIsHidden\": true,\n      \"UniqueBack\": false,\n      \"Type\": 0\n      },',
    #                   sep = "")
    
    deckPicMain = paste('        \"',i,'\": {\n          \"FaceURL\": \"',UrlFronts,cardnames[[1]][[i]],'\",\n          \"BackURL\": \"',UrlBacks,substring(cardnames[[1]][[i]], 1, 3),'.png\",\n          \"NumWidth\": 1,\n          \"NumHeight\": 1,\n          \"BackIsHidden\": true,\n          \"UniqueBack\": false,\n          \"Type\": 0\n        },\n',sep = "")
    
    deckPicHeader = paste(deckPicHeader,deckPicMain,sep = "")
  }
  
  deckPicHeader = substring(deckPicHeader, 1, (nchar(deckPicHeader)-2))
  
  ##single Card
  
  singleHeader = '
      },
      "LuaScript": "",
      "LuaScriptState": "",
      "XmlUI": "",
      "ContainedObjects": [
'
  
  for(i in 1:length(cardnames[[1]])){
    
    CardBigIds = seq(from = 1, to = length(cardnames[[1]]))*100
    
    cardName = substring(cardnames[[1]][[i]], 11, (nchar(cardnames[[1]][[i]])-4))
    
    singleMain = paste('        {\n          \"GUID\": \"\",\n          \"Name\": \"CardCustom\",\n          \"Transform\": {\n            \"posX\": 0,\n            \"posY\": 0,\n            \"posZ\": 0,\n            \"rotX\": 0,\n            \"rotY\": 0,\n            \"rotZ\": 0,\n            \"scaleX\": 1.0,\n            \"scaleY\": 1.0,\n            \"scaleZ\": 1.0\n          },\n          \"Nickname\": \"',cardName,'\",\n          \"Description\": \"\",\n          \"GMNotes\": \"\",\n          \"AltLookAngle\": {\n            \"x\": 0.0,\n            \"y\": 0.0,\n            \"z\": 0.0\n          },\n          \"ColorDiffuse\": {\n            \"r\": 0.713235259,\n            \"g\": 0.713235259,\n            \"b\": 0.713235259\n          },\n          \"Tags\": [\n            \"card\"\n          ],\n          \"LayoutGroupSortIndex\": 0,\n          \"Value\": 0,\n          \"Locked\": false,\n          \"Grid\": true,\n          \"Snap\": true,\n          \"IgnoreFoW\": false,\n          \"MeasureMovement\": false,\n          \"DragSelectable\": true,\n          \"Autoraise\": true,\n          \"Sticky\": true,\n          \"Tooltip\": true,\n          \"GridProjection\": false,\n          \"HideWhenFaceDown\": true,\n          \"Hands\": true,\n          \"CardID\": ',CardBigIds[i],',\n          \"SidewaysCard\": false,\n          \"CustomDeck\": {\n            \"',i,'\": {\n              \"FaceURL\": \"',UrlFronts,cardnames[[1]][[i]],'\",\n              \"BackURL\": \"',UrlBacks,substring(cardnames[[1]][[i]], 1, 3),'.png\",\n              \"NumWidth\": 1,\n              \"NumHeight\": 1,\n              \"BackIsHidden\": true,\n              \"UniqueBack\": false,\n              \"Type\": 0\n            }\n          },\n          \"LuaScript\": \"\",\n          \"LuaScriptState\": \"\",\n          \"XmlUI\": \"\"\n        },\n',
                       sep = "")
    
    singleHeader = paste(singleHeader,singleMain,sep = "")
    
  }
  
  singleHeader = substring(singleHeader, 1, (nchar(singleHeader)-12))
  
  #ratTail
  
  ratTail = paste("\n        }\n      ]\n    }\n  ]\n}",sep = "")
  
  return(paste(DeackHeader,deckId,deckPicHeader,singleHeader,ratTail))
  
}

####


setwd(SavePathOfTheJsons)

for (i in 1:length(AllJsonFiles)){
  
  cardnames = AllJsonFiles[i]
  
  TempFile = GetJson(UrlFronts = UrlFronts,UrlBacks = UrlBacks,cardnames = cardnames)
  
  write.table(TempFile,file = paste(getwd(),"/",names(cardnames),".json",sep=""),
              append = FALSE,na = "", sep = ";", row.names = F, col.names = F,quote = F)
  
}









