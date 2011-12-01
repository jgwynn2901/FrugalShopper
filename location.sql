REATE TABLE locations
(
   id serial, 
   user_id integer NOT NULL, 
   formatted_address character varying(255) NOT NULL, 
   latitude numeric(18,13) NOT NULL, 
   longitude numeric(18,13) NOT NULL, 
   created_date timestamp without time zone NOT NULL DEFAULT now(), 
   modified_date time without time zone NOT NULL DEFAULT now(), 
   CONSTRAINT location_id PRIMARY KEY (id), 
   CONSTRAINT location_to_user FOREIGN KEY (user_id) REFERENCES users (id) ON UPDATE NO ACTION ON DELETE NO ACTION
) 
WITH (
  OIDS = FALSE
)
;
ALTER TABLE locations OWNER TO shopper;
