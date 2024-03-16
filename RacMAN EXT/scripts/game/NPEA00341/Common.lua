function sly1_set_coincount(coins)
	Memory.WriteInt(0x3E8BF4, coins)
end

function sly1_get_cointcount()
	return Memory.ReadInt(0x3E8BF4)
end

function sly1_save_pos()
	sly1_saved_pos = API:ReadMemory(Memory.ReadInt(0x429904) + 0x100, 12)
	sly1_saved_vel = API:ReadMemory(Memory.ReadInt(0x429904) + 0x150, 12)
end

function sly1_load_pos()
	if sly1_saved_pos ~= nil then
		API:WriteMemory(Memory.ReadInt(0x429904) + 0x100, sly1_saved_pos)
	end
	if sly1_saved_vel ~= nil then
		API:WriteMemory(Memory.ReadInt(0x429904) + 0x150, sly1_saved_vel)
	end
end

function sly1_unlock_gadgets()
	local table = {
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1
	}
	API:WriteMemory(0x3e8c02, Convert.TableToByteArray(table))
end

function sly1_remove_gadgets()
	local table = {
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0
	}
	API:WriteMemory(0x3e8c02, Convert.TableToByteArray(table))
end

local sly1_freeze_charms_subid = nil
function rc3_set_freeze_charms(enabled)
	if enabled then
		sly1_freeze_charms_subid = API:FreezeMemory(0x3e8bf0, Convert.IntToByteArray(200,4))
	else
		API:ReleaseSubID(sly1_freeze_charms_subid)
	end
end