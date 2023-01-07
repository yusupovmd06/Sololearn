
create table roles(
    id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    name varchar(50),
    description varchar(50)
)

create table users(
    id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    added_at datetime,
    is_active bit,
    added_by int,
    is_deleted bit,
    fullname varchar(50),
    email varchar(50),
    password varchar(50),
    role_id int references roles(id)
);

create table subject(
    id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    added_at datetime,
    is_active bit,
    added_by int references users,
    is_deleted bit,
    name varchar(50),
    description varchar(50)
);

create table test(
    id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    added_at datetime,
    is_active bit,
    added_by int references users,
    is_deleted bit,
    name varchar(50),
    description varchar(50),
    subject_id int references subject
);

create table question(
    id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    added_at datetime,
    is_active bit,
    added_by int references users,
    is_deleted bit,
    body varchar(50),
    type varchar(50),
    difficulty int,
    test_id int references test,
);

create table answer(
    id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    added_at datetime,
    is_active bit,
    added_by int references users,
    is_deleted bit,
    body varchar(50),
    is_true bit,
    question_id int references question
);

create table user_result(
    id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    added_at datetime,
    is_active bit,
    added_by int references users,
    is_deleted bit,
    question_id int references question,
    answer_id int references answer,
    answer_body varchar(50)
);