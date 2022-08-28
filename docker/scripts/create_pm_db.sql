CREATE TYPE preference_type AS ENUM ('boolean', 'integer', 'text', 'float');
CREATE TYPE person_type AS ENUM ('admin', 'solution_manager', 'consumer');

CREATE TABLE preference (
    "id" serial NOT NULL,
    "name" varchar(255) NOT NULL,
    "description" varchar(255) DEFAULT NULL,
    "preference_type" preference_type NOT NULL,
    "universal" BOOLEAN DEFAULT FALSE,
    "encrypted" BOOLEAN DEFAULT FALSE,
    PRIMARY KEY ("id")
);

CREATE TABLE solution(
    "id" serial NOT NULL,
    "name" varchar(255) NOT NULL,
    "host" varchar(255) NOT NULL,
    PRIMARY KEY ("id")
);

CREATE TABLE solution_preference(
    "id" serial NOT NULL,
    "solution_id" integer NOT NULL,
    "preference_id" integer NOT NULL,
    PRIMARY KEY ("id"),
    CONSTRAINT fk_solution_preference_solution_id FOREIGN KEY (solution_id) REFERENCES solution (id),
    CONSTRAINT fk_solution_preference_preference_id FOREIGN KEY (preference_id) REFERENCES preference (id)
);

CREATE TABLE person(
    "id" bigserial NOT NULL,
    "external_auth_id" varchar(255) NOT NULL,
    "name" varchar(255) NOT NULL,
    "person_type" person_type NOT NULL,
    PRIMARY KEY (id)    
);

CREATE TABLE person_preference(
    "id" bigserial NOT NULL, 
    "person_id" bigint NOT NULL,
    "preference_id" integer NOT NULL,
    "preference_value" varchar(255) NOT NULL,
    "encrypted_key" varchar(255) DEFAULT NULL,
    PRIMARY KEY ("id"),
    CONSTRAINT fk_person_preference_person_id FOREIGN KEY (person_id) REFERENCES person (id),
    CONSTRAINT fk_person_preference_preference_id FOREIGN KEY (preference_id) REFERENCES preference (id)
);

INSERT INTO "solution"
("id", "name", "host")
VALUES(1,'mobile_app', 'http://awesomeapp.com'),
VALUES(2,'game', 'http://awesomegame.com'),
VALUES(3,'web_site', 'http://awesomesite.com');

INSERT INTO "solution"
("id", "name", "host")
VALUES(1,'mobile_app', 'http://awesomeapp.com'),
VALUES(2,'game', 'http://awesomegame.com'),
VALUES(3,'web_site', 'http://awesomesite.com');