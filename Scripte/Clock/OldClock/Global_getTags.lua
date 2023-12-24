CardIdList = {}
local secondsToAdd = 20
local isPaused = false

function onObjectEnterZone(zone, object)
    if zone.guid == "d64a0b" then
        if object.hasTag("card") then
            objectGuid = object.getGUID();
            if has_key(CardIdList,objectGuid) then
                if object.name != "Deck" then

                    CardIdList[objectGuid] = objectGuid

                    gameClock1 = getObjectFromGUID("460907")
                    gameClock2 = getObjectFromGUID("6300d7")
                    gameClock3 = getObjectFromGUID("8d9824")
                    gameClock4 = getObjectFromGUID("ed6655")
                    gameClock5 = getObjectFromGUID("3a891d")
                    gameClock6 = getObjectFromGUID("2a445d")
                    gameClock7 = getObjectFromGUID("a6560c")
                    gameClock8 = getObjectFromGUID("0d5465")
                    gameClock9 = getObjectFromGUID("42711e")
                    gameClock10 = getObjectFromGUID("05fe9d")

                    CurrentTime = gameClock1.getValue()

                    if CurrentTime ~= 0 then

                        CurrentTime = CurrentTime+secondsToAdd+1

                        gameClock1.call("addxSeconds", CurrentTime)
                        gameClock2.call("addxSeconds", CurrentTime)
                        gameClock3.call("addxSeconds", CurrentTime)
                        gameClock4.call("addxSeconds", CurrentTime)
                        gameClock5.call("addxSeconds", CurrentTime)
                        gameClock6.call("addxSeconds", CurrentTime)
                        gameClock7.call("addxSeconds", CurrentTime)
                        gameClock8.call("addxSeconds", CurrentTime)
                        gameClock9.call("addxSeconds", CurrentTime)
                        gameClock10.call("addxSeconds", CurrentTime)

                        isPaused = false

                        printToAll(object.getName(), {r=0,g=1,b=0})

                    else

                        --printToAll(object.getName(), {r=1,g=0,b=0})

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

function RestCardList()
    CardIdList = {}
end

function StartTimer()

    gameClock1 = getObjectFromGUID("460907")
    gameClock2 = getObjectFromGUID("6300d7")
    gameClock3 = getObjectFromGUID("8d9824")
    gameClock4 = getObjectFromGUID("ed6655")
    gameClock5 = getObjectFromGUID("3a891d")
    gameClock6 = getObjectFromGUID("2a445d")
    gameClock7 = getObjectFromGUID("a6560c")
    gameClock8 = getObjectFromGUID("0d5465")
    gameClock9 = getObjectFromGUID("42711e")
    gameClock10 = getObjectFromGUID("05fe9d")

    gameClock1.Clock.setValue(secondsToAdd*2)
    gameClock2.Clock.setValue(secondsToAdd*2)
    gameClock3.Clock.setValue(secondsToAdd*2)
    gameClock4.Clock.setValue(secondsToAdd*2)
    gameClock5.Clock.setValue(secondsToAdd*2)
    gameClock6.Clock.setValue(secondsToAdd*2)
    gameClock7.Clock.setValue(secondsToAdd*2)
    gameClock8.Clock.setValue(secondsToAdd*2)
    gameClock9.Clock.setValue(secondsToAdd*2)
    gameClock10.Clock.setValue(secondsToAdd*2)

    isPaused = true

end

function UpdateSeconds(seconds)

    if (secondsToAdd > 5 or seconds > 0) and (secondsToAdd < 60 or seconds < 0) then

        secondsToAdd = secondsToAdd+seconds

        masterControl = getObjectFromGUID("813545")
        masterControl.editButton({index=0, label=secondsToAdd})
    end
end

function Reset()

    gameClock1 = getObjectFromGUID("460907")
    gameClock2 = getObjectFromGUID("6300d7")
    gameClock3 = getObjectFromGUID("8d9824")
    gameClock4 = getObjectFromGUID("ed6655")
    gameClock5 = getObjectFromGUID("3a891d")
    gameClock6 = getObjectFromGUID("2a445d")
    gameClock7 = getObjectFromGUID("a6560c")
    gameClock8 = getObjectFromGUID("0d5465")
    gameClock9 = getObjectFromGUID("42711e")
    gameClock10 = getObjectFromGUID("05fe9d")

    gameClock1.Clock.setValue(0)
    gameClock2.Clock.setValue(0)
    gameClock3.Clock.setValue(0)
    gameClock4.Clock.setValue(0)
    gameClock5.Clock.setValue(0)
    gameClock6.Clock.setValue(0)
    gameClock7.Clock.setValue(0)
    gameClock8.Clock.setValue(0)
    gameClock9.Clock.setValue(0)
    gameClock10.Clock.setValue(0)

    isPaused = true

end






local frame_count = 0
function onFixedUpdate()
frame_count = frame_count + 1
    if frame_count >= 10 then

        gameClock1 = getObjectFromGUID("460907")
        gameClock2 = getObjectFromGUID("6300d7")
        gameClock3 = getObjectFromGUID("8d9824")
        gameClock4 = getObjectFromGUID("ed6655")
        gameClock5 = getObjectFromGUID("3a891d")
        gameClock6 = getObjectFromGUID("2a445d")
        gameClock7 = getObjectFromGUID("a6560c")
        gameClock8 = getObjectFromGUID("0d5465")
        gameClock9 = getObjectFromGUID("42711e")
        gameClock10 = getObjectFromGUID("05fe9d")

        if gameClock1.getValue() ~= 0 then
            if gameClock1.Clock.paused or gameClock2.Clock.paused or gameClock3.Clock.paused then
                if not(gameClock1.Clock.paused) or not(gameClock2.Clock.paused) or not(gameClock3.Clock.paused) or not(gameClock4.Clock.paused) or not(gameClock5.Clock.paused) or not(gameClock6.Clock.paused) or not(gameClock7.Clock.paused) or not(gameClock8.Clock.paused) or not(gameClock9.Clock.paused) or not(gameClock10.Clock.paused) then
                    ClockClicked()
                end
            end
            frame_count = 0
        end
    end
end


function ClockClicked()
    gameClock1 = getObjectFromGUID("460907")
    gameClock2 = getObjectFromGUID("6300d7")
    gameClock3 = getObjectFromGUID("8d9824")
    gameClock4 = getObjectFromGUID("ed6655")
    gameClock5 = getObjectFromGUID("3a891d")
    gameClock6 = getObjectFromGUID("2a445d")
    gameClock7 = getObjectFromGUID("a6560c")
    gameClock8 = getObjectFromGUID("0d5465")
    gameClock9 = getObjectFromGUID("42711e")
    gameClock10 = getObjectFromGUID("05fe9d")
    CurrentTime = gameClock1.getValue()

    --Not Paused -> Pause all Clocks
    if not(isPaused) then

        gameClock1.Clock.setValue(CurrentTime)
        gameClock2.Clock.setValue(CurrentTime)
        gameClock3.Clock.setValue(CurrentTime)
        gameClock4.Clock.setValue(CurrentTime)
        gameClock5.Clock.setValue(CurrentTime)
        gameClock6.Clock.setValue(CurrentTime)
        gameClock7.Clock.setValue(CurrentTime)
        gameClock8.Clock.setValue(CurrentTime)
        gameClock9.Clock.setValue(CurrentTime)
        gameClock10.Clock.setValue(CurrentTime)

    --Is Paused -> Unpause all Clock
    else
        gameClock1.call("addxSeconds", CurrentTime)
        gameClock2.call("addxSeconds", CurrentTime)
        gameClock3.call("addxSeconds", CurrentTime)
        gameClock4.call("addxSeconds", CurrentTime)
        gameClock5.call("addxSeconds", CurrentTime)
        gameClock6.call("addxSeconds", CurrentTime)
        gameClock7.call("addxSeconds", CurrentTime)
        gameClock8.call("addxSeconds", CurrentTime)
        gameClock9.call("addxSeconds", CurrentTime)
        gameClock10.call("addxSeconds", CurrentTime)

    end

    if isPaused then
        isPaused = false
    else
        isPaused = true
    end

end