CREATE TABLE todos (
	"id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY,
	"titulo" text NOT NULL,
	"prazo" timestamptz NULL,
	"descricao" text NOT NULL,
	"status" int4 NOT NULL,
	CONSTRAINT "PK_Todos" PRIMARY KEY ("Id")
);