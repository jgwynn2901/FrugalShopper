CREATE OR REPLACE FUNCTION update_lastmodified_column() 
        RETURNS TRIGGER AS '
  BEGIN
    NEW.lastmodified = NOW();
    RETURN NEW;
  END;
' LANGUAGE 'plpgsql';


CREATE TRIGGER update_locations_modtime BEFORE UPDATE
  ON users FOR EACH ROW EXECUTE PROCEDURE
  update_lastmodified_column();
  
  
CREATE TRIGGER update_locations_modtime BEFORE UPDATE
  ON locations FOR EACH ROW EXECUTE PROCEDURE
  update_lastmodified_column();