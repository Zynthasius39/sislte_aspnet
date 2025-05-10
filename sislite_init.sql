CREATE TABLE Announce
(
    announce_id SERIAL PRIMARY KEY,
    title       TEXT      NOT NULL,
    message     TEXT      NOT NULL,
    date        TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);
CREATE TABLE Attendance
(
    att_id     SERIAL PRIMARY KEY,
    student_id INT     NOT NULL,
    course_id  INT     NOT NULL,
    date       DATE    NOT NULL,
    presence   BOOLEAN NOT NULL,
    FOREIGN KEY (student_id) REFERENCES Student (student_id),
    FOREIGN KEY (course_id) REFERENCES Course (course_id)
);
CREATE TABLE Course
(
    course_id SERIAL PRIMARY KEY,
    code      VARCHAR(20) NOT NULL,
    name      TEXT        NOT NULL,
    theory    INT         NOT NULL,
    ects      INT         NOT NULL
);
CREATE TABLE Program
(
    program_id SERIAL PRIMARY KEY,
    code       VARCHAR(20) NOT NULL,
    name       TEXT        NOT NULL,
    lang       VARCHAR(10) NOT NULL
);
CREATE TABLE Grade
(
    student_id INT PRIMARY KEY,
    grades     JSONB NOT NULL,
    FOREIGN KEY (student_id) REFERENCES Student (student_id)
);
CREATE TABLE Semesters
(
    semester_id SERIAL PRIMARY KEY,
    student_ids INT[] NOT NULL,
    course_ids  INT[] NOT NULL,
    spa         NUMERIC(4, 2),
    start_date  DATE NOT NULL,
    end_date    DATE NOT NULL
);
CREATE TABLE Student
(
    student_id      SERIAL PRIMARY KEY,
    password        CHAR(64) NOT NULL,
    email           TEXT     NOT NULL UNIQUE,
    register_date   TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    last_login_date TIMESTAMP,
    last_login_ip   INET,
    advisor         TEXT,
    prefs           JSONB,
    gpa             NUMERIC(4, 2),
    tatc            INT,
    tacc            INT,
    sac             INT
);
