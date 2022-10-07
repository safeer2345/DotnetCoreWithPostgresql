
CREATE TABLE IF NOT EXISTS "Plans" (
 "Id" uuid NOT NULL,
 "Name" text NOT NULL,
 "Price" integer NOT NULL,
 "CreatedAt" timestamp with time zone NOT NULL,
 CONSTRAINT "PK_Plans" PRIMARY KEY ("Id")
);

