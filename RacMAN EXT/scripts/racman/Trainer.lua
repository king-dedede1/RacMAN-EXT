-- Utility for trainer control actions.
Trainer = {}
Trainer["GetPanel"] = function()
	return Racman.MainForm.TrainerPanel
end

-- maybe replace this with __index metatable?
Trainer["GetControlByName"] = function(name)
	return Racman.MainForm.TrainerPanel.Controls[name]
end