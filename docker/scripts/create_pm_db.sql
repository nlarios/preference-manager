CREATE TYPE preference_type_t AS ENUM ('BOOLEAN', 'INTEGER', 'TEXT', 'FlOAT');
CREATE TYPE person_type_t AS ENUM ('ADMIN', 'SOLUTION_MANAGER', 'CONSUMER');

CREATE TABLE preference (
    "id" serial NOT NULL,
    "name" varchar(255) NOT NULL,
    "preference_type" preference_type_t NOT NULL,
    "universal" BOOLEAN NOT NULL,
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
    "person_type" person_type_t NOT NULL,
    PRIMARY KEY (id)    
);

CREATE TABLE person_preference(
    "id" bigserial NOT NULL, 
    "person_id" bigint NOT NULL,
    "preference_id" integer NOT NULL,
    "preference_value" varchar(255) NOT NULL,
    "encrypted_value" varchar(255) DEFAULT NULL,
    PRIMARY KEY ("id"),
    CONSTRAINT fk_person_preference_person_id FOREIGN KEY (person_id) REFERENCES person (id),
    CONSTRAINT fk_person_preference_preference_id FOREIGN KEY (preference_id) REFERENCES preference (id)
);