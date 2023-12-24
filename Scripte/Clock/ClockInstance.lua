function generateButtonParamiters()
    timer1 = {
        click_function='doNothing' , function_owner=self , label='30' ,
        position={0.5,0,0} , rotation={0,-90,90} , width=500 , height=450 , font_size=250
    }
    timer2 = {
        click_function='doNothing' , function_owner=self , label='30' ,
        position={-0.5,0,0} , rotation={-180,-90,90} , width=500 , height=450 , font_size=250
    }
    minertimer1 = {
        click_function='doNothing' , function_owner=self , label='30' ,
        position={0,0,0.5} , rotation={-90,180,180} , width=450 , height=450 , font_size=250
    }
    minertimer2 = {
        click_function='doNothing' , function_owner=self , label='30' ,
        position={0,0,-0.5} , rotation={90,0,180} , width=450 , height=450 , font_size=250
    }
    Button = {
        click_function='startButton' , function_owner=self , label='[▶︎]' ,
        position={0,0.5,0} , rotation={0,-90,0} , width=150 , height=150 , font_size=50
    }
end

function doNothing()
end

function startButton()
    Global.call("startStopTime")
end

function updateTime(currentTime)
    self.editButton({index=0, label=currentTime})
    self.editButton({index=1, label=currentTime})
    self.editButton({index=2, label=currentTime})
    self.editButton({index=3, label=currentTime})
end



function onload(saved_data)
    generateButtonParamiters()

    self.createButton(timer1)
    self.createButton(timer2)
    self.createButton(minertimer1)
    self.createButton(minertimer2)
    self.createButton(Button)
end