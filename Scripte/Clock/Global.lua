local currentTime = 30
local addTime = 10
local timerIsRunning = false
local ClockLock = false
CardIdList = {}

MusicPlayer.setCurrentAudioclip({
    url = "https://www.user.tu-berlin.de/timkroeger/TableTop/assats/2secondsRemain.wav",
    title = "EndTurnSound"
})

function onObjectEnterZone(zone, object)
    if zone.guid == "d64a0b" then
        if object.hasTag("card") then
            objectGuid = object.getGUID();
            if object.name != "Deck" then
                if has_key(CardIdList,objectGuid) then

                    local rotation = object.getRotation()
                    if(rotation[3] >= math.abs(10))
                    then
                        --Face Down
                    else
                        --Face up
                        CardIdList[objectGuid] = objectGuid

                        --Cards played after timer
                        if(ClockLock)
                        then
                            printToAll(object.getName(), {r=1,g=0,b=0})
                        else 
                            --Add Time
                            currentTime = currentTime + addTime
                            if(currentTime > 60)
                            then
                                currentTime = 60
                            end

                            --update Clock times
                            clock1 = getObjectFromGUID("b427dc")
                            clock2 = getObjectFromGUID("d1758e")
                            clock3 = getObjectFromGUID("878887")
                            clock4 = getObjectFromGUID("21b2fd")
                            clock5 = getObjectFromGUID("0338b5")
                
                            clock1.call("updateTime", currentTime)
                            clock2.call("updateTime", currentTime)
                            clock3.call("updateTime", currentTime)
                            clock4.call("updateTime", currentTime)
                            clock5.call("updateTime", currentTime)
                        end
                    end
                end
            end
        end
    end
end

function has_key(table, key)
    return table[key]==nil
end


function addAllExsistingElementToCarlist(newGUID)
    CardIdList[newGUID] = newGUID
end


function Reset()

    currentTime = 30
    ClockLock = false
    timerIsRunning = false
    CardIdList = {}

    if not(TimerElement == nil) then 
        Wait.stop(TimerElement)
    end

    clock1 = getObjectFromGUID("b427dc")
    clock2 = getObjectFromGUID("d1758e")
    clock3 = getObjectFromGUID("878887")
    clock4 = getObjectFromGUID("21b2fd")
    clock5 = getObjectFromGUID("0338b5")

    clock1.call("updateTime", 30)
    clock2.call("updateTime", 30)
    clock3.call("updateTime", 30)
    clock4.call("updateTime", 30)
    clock5.call("updateTime", 30)

    print("Time was reset")

end


function UpdateSeconds(seconds)

    if (addTime > 5 or seconds > 0) and (addTime < 30 or seconds < 0) then

        addTime = addTime+seconds

        masterControl = getObjectFromGUID("813545")
        masterControl.editButton({index=0, label=addTime})
    end
end




function runTimer()
    local clock = Wait.time(
        function()
            currentTime = currentTime - 1

            print(currentTime)
            clock1 = getObjectFromGUID("b427dc")
            clock2 = getObjectFromGUID("d1758e")
            clock3 = getObjectFromGUID("878887")
            clock4 = getObjectFromGUID("21b2fd")
            clock5 = getObjectFromGUID("0338b5")

            clock1.call("updateTime", currentTime)
            clock2.call("updateTime", currentTime)
            clock3.call("updateTime", currentTime)
            clock4.call("updateTime", currentTime)
            clock5.call("updateTime", currentTime)

            if(currentTime == 0)
            then
                Wait.stop(TimerElement)
                print("Turn Ends!")

                MusicPlayer.play()

                ClockLock = true
            end

        end,
        1,
        999999
    )
    return clock
end

function startStopTime()
    if(not(ClockLock))
    then
        if(not(timerIsRunning))
        then
            print(currentTime, "- Timer start")
            TimerElement = runTimer()
            timerIsRunning = true
        else
            Wait.stop(TimerElement)
            timerIsRunning = false
            printToAll("Timer Stoped!", {r=0,g=1,b=0})
        end
    else
        print("Clock is locked!")
    end
end