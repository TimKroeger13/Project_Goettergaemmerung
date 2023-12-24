function generateButtonParamiters()
    timer = {
        click_function='doNothing' , function_owner=self , label='20' ,
        position={0,0.6,0.3} , rotation={0,180,0} , width=200 , height=120 , font_size=80
    }
    minus = {
        click_function='minusfunc' , function_owner=self , label='<' ,
        position={0.3,0.6,0.3} , rotation={0,180,0} , width=100 , height=100 , font_size=60
    }
    plus = {
        click_function='plusfunc' , function_owner=self , label='>' ,
        position={-0.3,0.6,0.3} , rotation={0,180,0} , width=100 , height=100 , font_size=60
    }
    set = {
        click_function='startButton' , function_owner=self , label='Set' ,
        position={0,0.6,-0.1} , rotation={0,180,0} , width=500 , height=200 , font_size=100
    }
    reset = {
        click_function='resetfunc' , function_owner=self , label='Reset' ,
        position={0.35,0.6,-0.4} , rotation={0,180,0} , width=140 , height=80 , font_size=50
    }
end

function minusfunc()
    Global.call("UpdateSeconds", -1)
end

function plusfunc()
    Global.call("UpdateSeconds", 1)
end

function resetfunc()
    Global.call("Reset")
end



function startButton()

    Global.call("RestCardList")

    zoneGUID = getObjectFromGUID("d64a0b")
    zoneObjects = zoneGUID.getObjects()

    for key,value in pairs(zoneObjects) do
        Global.call("addAllExsistingElementToCarlist",value.getGUID())
    end

    print("New Round is set up!")
    Global.call("StartTimer")
end

function doNothing()
end



function onload(saved_data)
    generateButtonParamiters()

    self.createButton(timer)
    self.createButton(minus)
    self.createButton(plus)
    self.createButton(set)
    self.createButton(reset)
end

   --print(self.getButtons()[1].label)

   --self.editButton({index=0, label="18"})
--print(value.getGUID());
--printToAll(value.getName(), {r=1,g=0,b=0})


--for key,value in pairs(zoneObjects) do

--print(value.getGUID())

--end