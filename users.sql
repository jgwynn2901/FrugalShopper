CREATE TABLE users
(
   id serial NOT NULL, 
   user_name character varying(18) NOT NULL, 
   password character varying(256) NOT NULL, 
   email_address character varying(256), 
   created_date timestamp without time zone NOT NULL DEFAULT now(), 
   modified_date timestamp without time zone NOT NULL DEFAULT now(), 
   CONSTRAINT "userId" PRIMARY KEY (id)
) 
WITH (
  OIDS = FALSE
)
;
ALTER TABLE users OWNER TO shopper;
COMMENT ON COLUMN users.id IS 'primary key';
COMMENT ON COLUMN users.password IS 'encrypted using rindge';
COMMENT ON TABLE users
  IS 'user store for mvc shopping app';
