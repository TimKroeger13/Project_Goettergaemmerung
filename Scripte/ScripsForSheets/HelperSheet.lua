-- Code by: Tim Kröger
-- Used sorce code from Alforno


local textAttack = "0"
local textAttackWidth = 650
local textAttackheight = 160
local textAttackFontSize = 130
local textAttack_x = 2.05
local textAttack_y = -0.325

local textFaith = "0"
local textFaithWidth = 650
local textFaithheight = 160
local textFaithFontSize = 130
local textFaith_x = 2.05
local textFaith_y = 0.44

function onload(saved_data)
	createUI()
end


function createUI()

	self.createInput {
		input_function="AttackonInput",
		function_owner=self,
		label="0",
		alignment=3,
		position={textAttack_x,0.2,textAttack_y},
		rotation={0,0,0},
		width=textAttackWidth,
		height=textAttackheight,
		value=textAttack,
		font_size=textAttackFontSize,
		color={1, 1, 1,  1},
		font_color = BLACK,
        validation = 1
	}

	self.createInput {
		input_function="FaithonInput",
		function_owner=self,
		label="0",
		alignment=3,
		position={textFaith_x,0.2,textFaith_y},
		rotation={0,0,0},
		width=textFaithWidth,
		height=textFaithheight,
		value=textFaith,
		font_size=textFaithFontSize,
		color={1, 1, 1,  1},
		font_color = BLACK,
        validation = 1
	}

end

function waitRefreshUI()
	Wait.frames(refreshUI,1)
end

function refreshUI()

	self.removeInput(0);
	self.createInput {
		input_function="AttackonInput",
		function_owner=self,
		label="0",
		alignment=3,
		position={textAttack_x,0.2,textAttack_y},
		rotation={0,0,0},
		width=textAttackWidth,
		height=textAttackheight,
		value=textAttack,
		font_size=textAttackFontSize,
		color={1, 1, 1,  1},
		font_color = BLACK,
        validation = 2
	}

	self.createInput {
		input_function="FaithonInput",
		function_owner=self,
		label="0",
		alignment=3,
		position={textFaith_x,0.2,textFaith_y},
		rotation={0,0,0},
		width=textFaithWidth,
		height=textFaithheight,
		value=textFaith,
		font_size=textFaithFontSize,
		color={1, 1, 1,  1},
		font_color = BLACK,
        validation = 1
	}

end


function AttackonInput(self, ply, text, selected)
    if not selected then
        textAttack=text
    end
end

function FaithonInput(self, ply, text, selected)
    if not selected then
        textFaith=text
    end
end

















