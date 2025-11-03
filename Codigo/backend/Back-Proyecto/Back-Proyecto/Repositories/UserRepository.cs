using System;

			try
			{
				var UserToDelete = await _context.Users.FindAsync(id);
				if (UserToDelete == null)
				{
					return false;
					throw new Exception("Usuario No encontrado");
				}
				_context.Users.Remove(UserToDelete);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{ 
				return false;
				throw new Exception(ex.Message.ToString());
            }
        }
    }
}