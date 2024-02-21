function rc3_set_boltcount(bolts)
	Memory.WriteInt(0xC1E4DC, bolts)
end

function rc3_get_boltcount()
	return Memory.ReadInt(0xC1E4DC)
end

function rc3_load_planet(id, fast)
	fast = fast or true
	Memory.WriteInt(0xEE9310, 1)
	Memory.WriteInt(0xEE9314, id)

	-- not working right?
	if fast then
		Memory.WriteInt(0x134EBD4, 3)
		Timing.DoLater(function()
			Memory.WriteInt(0x134EE70, 0x0101)
		end, 200)
	end
end

function rc3_kill()
	Memory.WriteFloat(0xDA2878, -50)
end

function rc3_save_pos()
	rc3_saved_pos = API:ReadMemory(0xDA2870, 12)
end

function rc3_load_pos()
	if rc3_saved_pos ~= nil then
		API:WriteMemory(0xDA2870, rc3_saved_pos)
	end
end

local rc3_ghost_ratchet_subid = nil
function rc3_set_ghost_ratchet(enable)
	if enable then
		rc3_ghost_ratchet_subid = API:FreezeMemory(0xDA29DE, Convert.TableToByteArray({0,0,255,0}))
	else
		if rc3_ghost_ratchet_subid ~= nil then
			API:ReleaseSubID(rc3_ghost_ratchet_subid)
		else
			-- we called disable before enable, error
			Console.Warn('Tried to disable ghost ratchet before enabling')
		end
	end
end

function rc3_set_challenge_mode(v)
	Memory.WriteByte(0xC1E50E, v)
end

function rc3_get_challenge_mode()
	return Memory.ReadByte(0xC1E50E)
end

function rc3_set_armor(v)
	-- armor is meant to be 2 bytes but I cant be bothered to make a short converter so ill just do the 1
	Memory.WriteByte(0xC1e51D, v%256)
end

function rc3_get_armor()
	return Memory.ReadByte(0xC1e51D)
end

function rc3_unlock_skill_points()
local table = {
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1
	}
	API:WriteMemory(0xDA521D, Convert.TableToByteArray(table))
end

function rc3_reset_skill_points()
	local table = {
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0
	}
	API:WriteMemory(0xDA521D, Convert.TableToByteArray(table))
end

function rc3_setup_ngplus()
	Memory.WriteByte(0xC9165C, 0x7)
	Memory.WriteByte(0xC36BCC, 0x3)
	Memory.WriteByte(0xEF6098, 0xE)
	Memory.WriteInt(0xC4F918, 2)
	Memory.WriteInt(0x148A100, 1)
end

function rc3_set_quick_select_pause(v)
	Memory.WriteByte(0xC1E652, v)
end

function rc3_get_quick_select_pause()
	return Memory.ReadByte(0xC1E652)
end

local rc3_freeze_health_subid = nil
function rc3_set_freeze_health(enabled)
	if enabled then
		rc3_freeze_health_subid = API:FreezeMemory(0xDA5040, Convert.IntToByteArray(200))
	else
		API:ReleaseSubID(rc3_freeze_health_subid)
	end
end
