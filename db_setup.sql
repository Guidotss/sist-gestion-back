create extension if not exists "uuid-ossp";

create type "project_status" as enum ('Active', 'Inactive', 'Archived');


create table "users" ( 
    id uuid primary key default uuid_generate_v4(),
    name text not null,
    email text not null unique,
    password text not null,
    deleted boolean default false,
    created_at timestamp default now(),
    updated_at timestamp default now()
); 

create table "projects" (
    id uuid primary key default uuid_generate_v4(),
    name text not null,
    description text,
    owner_id uuid references "users"(id),
    repository text,
    status "project_status" default 'Active',
    deleted boolean default false,
    created_at timestamp default now(),
    updated_at timestamp default now()
); 


create table project_collaborators (
    project_id uuid not null references projects(id),
    user_id uuid not null references users(id),
    primary key (project_id, user_id)
); 




-- =========================
-- Usuarios (users)
-- =========================
INSERT INTO "users" (id, name, email, password)
VALUES
    ('11111111-1111-1111-1111-111111111111', 'Alice', 'alice@example.com', 'hash1'),
    ('22222222-2222-2222-2222-222222222222', 'Bob', 'bob@example.com', 'hash2'),
    ('33333333-3333-3333-3333-333333333333', 'Charlie', 'charlie@example.com', 'hash3'),
    ('44444444-4444-4444-4444-444444444444', 'Dave', 'dave@example.com', 'hash4'),
    ('55555555-5555-5555-5555-555555555555', 'Eve', 'eve@example.com', 'hash5'),
    ('66666666-6666-6666-6666-666666666666', 'Frank', 'frank@example.com', 'hash6'),
    ('77777777-7777-7777-7777-777777777777', 'Grace', 'grace@example.com', 'hash7'),
    ('88888888-8888-8888-8888-888888888888', 'Heidi', 'heidi@example.com', 'hash8'),
    ('99999999-9999-9999-9999-999999999999', 'Ivan', 'ivan@example.com', 'hash9'),
    ('dddddddd-dddd-dddd-dddd-dddddddddddd', 'Judy', 'judy@example.com', 'hash10');

-- =========================
-- Proyectos (projects)
-- =========================
INSERT INTO "projects" (id, name, description, owner_id, repository, status)
VALUES
    ('aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa', 'Project Alpha', 'Primer proyecto', '11111111-1111-1111-1111-111111111111', 'repo_alpha', 'Active'),
    ('bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb', 'Project Beta', 'Segundo proyecto', '22222222-2222-2222-2222-222222222222', 'repo_beta', 'Inactive'),
    ('cccccccc-cccc-cccc-cccc-cccccccccccc', 'Project Gamma', 'Tercer proyecto', '44444444-4444-4444-4444-444444444444', 'repo_gamma', 'Active'),
    ('eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee', 'Project Delta', 'Cuarto proyecto', '33333333-3333-3333-3333-333333333333', 'repo_delta', 'Active'),
    ('ffffffff-ffff-ffff-ffff-ffffffffffff', 'Project Epsilon', 'Quinto proyecto', '88888888-8888-8888-8888-888888888888', 'repo_epsilon', 'Archived');

-- =========================
-- Colaboradores en proyectos (project_collaborators)
-- =========================

-- Project Alpha: Propietario Alice; colaboradores: Bob, Charlie, Judy.
INSERT INTO project_collaborators (project_id, user_id)
VALUES
    ('aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa', '22222222-2222-2222-2222-222222222222'),
    ('aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa', '33333333-3333-3333-3333-333333333333'),
    ('aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa', 'dddddddd-dddd-dddd-dddd-dddddddddddd');

-- Project Beta: Propietario Bob; colaboradores: Alice, Eve, Frank.
INSERT INTO project_collaborators (project_id, user_id)
VALUES
    ('bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb', '11111111-1111-1111-1111-111111111111'),
    ('bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb', '55555555-5555-5555-5555-555555555555'),
    ('bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb', '66666666-6666-6666-6666-666666666666');

-- Project Gamma: Propietario Dave; colaboradores: Grace, Ivan.
INSERT INTO project_collaborators (project_id, user_id)
VALUES
    ('cccccccc-cccc-cccc-cccc-cccccccccccc', '77777777-7777-7777-7777-777777777777'),
    ('cccccccc-cccc-cccc-cccc-cccccccccccc', '99999999-9999-9999-9999-999999999999');

-- Project Delta: Propietario Charlie; colaboradores: Bob, Heidi, Ivan.
INSERT INTO project_collaborators (project_id, user_id)
VALUES
    ('eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee', '22222222-2222-2222-2222-222222222222'),
    ('eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee', '88888888-8888-8888-8888-888888888888'),
    ('eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee', '99999999-9999-9999-9999-999999999999');

-- Project Epsilon: Propietario Heidi; colaboradores: Alice, Frank, Grace, Judy.
INSERT INTO project_collaborators (project_id, user_id)
VALUES
    ('ffffffff-ffff-ffff-ffff-ffffffffffff', '11111111-1111-1111-1111-111111111111'),
    ('ffffffff-ffff-ffff-ffff-ffffffffffff', '66666666-6666-6666-6666-666666666666'),
    ('ffffffff-ffff-ffff-ffff-ffffffffffff', '77777777-7777-7777-7777-777777777777'),
    ('ffffffff-ffff-ffff-ffff-ffffffffffff', 'dddddddd-dddd-dddd-dddd-dddddddddddd');
