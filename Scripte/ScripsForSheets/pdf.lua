-- Code by: Tim Kröger
-- Used sorce code from MrStump from "Universal Counter Tokens"

-- -0.8 <- button distance

function generateButtonParamiters()
    left = {
        click_function='pageToLeft' , function_owner=self , label='<' ,
        position={-0.25,0.5,0} , rotation={0,0,0} , width=170 , height=300 , font_size=200
    }
    
    right = {
        click_function='pageToRight' , function_owner=self , label='>' ,
        position={0.25,0.5,0} , rotation={0,0,0} , width=170 , height=300 , font_size=200
    }
end

local leftPage = getObjectFromGUID("c809dd")
local rightPage = getObjectFromGUID("d8800a")

function pageToLeft()

    curRightPage = rightPage.Book.getPage(false)

    if curRightPage<1 then

        curRightPage = 1

    end

    rightPage.Book.setPage(curRightPage-2, false)
    leftPage.Book.setPage(curRightPage-3, false)

end

function pageToRight()

    curRightPage = rightPage.Book.getPage(false)

    rightPage.Book.setPage(curRightPage+2, false)
    leftPage.Book.setPage(curRightPage+1, false)


    --Check pages

    testLeft = leftPage.Book.getPage(false)
    testRight = rightPage.Book.getPage(false)

    if testLeft>testRight then

        leftPage.Book.setPage(curRightPage-1, false)

    end



    testLeft = leftPage.Book.getPage(false)
    testRight = rightPage.Book.getPage(false)

    print()
    print(testLeft)
    print(testRight)


end

function donothing() end

-- onload

function onload(saved_data)
    generateButtonParamiters()

    self.createButton(left)
    self.createButton(right)

end









