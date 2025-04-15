--
-- PostgreSQL database dump
--

-- Dumped from database version 17.4
-- Dumped by pg_dump version 17.4

-- Started on 2025-04-16 02:54:58

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 221 (class 1255 OID 16455)
-- Name: update_timestamp(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.update_timestamp() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    NEW.updated_at = CURRENT_TIMESTAMP;
    RETURN NEW;
END;
$$;


ALTER FUNCTION public.update_timestamp() OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 218 (class 1259 OID 16443)
-- Name: applications; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.applications (
    id integer NOT NULL,
    email character varying(255) NOT NULL,
    name character varying(255) NOT NULL,
    passport character varying(50) NOT NULL,
    address text NOT NULL,
    migrant_name character varying(255) NOT NULL,
    migrant_passport character varying(50) NOT NULL,
    visa_number character varying(50),
    migration_card character varying(50),
    status character varying(20) NOT NULL,
    created_at timestamp with time zone DEFAULT CURRENT_TIMESTAMP,
    updated_at timestamp with time zone DEFAULT CURRENT_TIMESTAMP
);


ALTER TABLE public.applications OWNER TO postgres;

--
-- TOC entry 4817 (class 0 OID 0)
-- Dependencies: 218
-- Name: COLUMN applications.email; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN public.applications.email IS 'Email владельца';


--
-- TOC entry 4818 (class 0 OID 0)
-- Dependencies: 218
-- Name: COLUMN applications.name; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN public.applications.name IS 'ФИО владельца';


--
-- TOC entry 4819 (class 0 OID 0)
-- Dependencies: 218
-- Name: COLUMN applications.passport; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN public.applications.passport IS 'Паспортные данные владельца';


--
-- TOC entry 4820 (class 0 OID 0)
-- Dependencies: 218
-- Name: COLUMN applications.address; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN public.applications.address IS 'Адрес объекта';


--
-- TOC entry 4821 (class 0 OID 0)
-- Dependencies: 218
-- Name: COLUMN applications.migrant_name; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN public.applications.migrant_name IS 'ФИО мигранта';


--
-- TOC entry 4822 (class 0 OID 0)
-- Dependencies: 218
-- Name: COLUMN applications.migrant_passport; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN public.applications.migrant_passport IS 'Паспортные данные мигранта';


--
-- TOC entry 4823 (class 0 OID 0)
-- Dependencies: 218
-- Name: COLUMN applications.visa_number; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN public.applications.visa_number IS 'Номер визы';


--
-- TOC entry 4824 (class 0 OID 0)
-- Dependencies: 218
-- Name: COLUMN applications.migration_card; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN public.applications.migration_card IS 'Номер миграционной карты';


--
-- TOC entry 4825 (class 0 OID 0)
-- Dependencies: 218
-- Name: COLUMN applications.status; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN public.applications.status IS 'Статус заявки';


--
-- TOC entry 217 (class 1259 OID 16442)
-- Name: applications_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.applications_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.applications_id_seq OWNER TO postgres;

--
-- TOC entry 4826 (class 0 OID 0)
-- Dependencies: 217
-- Name: applications_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.applications_id_seq OWNED BY public.applications.id;


--
-- TOC entry 220 (class 1259 OID 16466)
-- Name: users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users (
    id integer NOT NULL,
    name character varying(100) NOT NULL,
    email character varying(100) NOT NULL,
    role character varying(20) NOT NULL,
    online boolean DEFAULT false NOT NULL,
    created_at timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    last_activity timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    password character varying(100)
);


ALTER TABLE public.users OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 16465)
-- Name: users_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.users_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.users_id_seq OWNER TO postgres;

--
-- TOC entry 4827 (class 0 OID 0)
-- Dependencies: 219
-- Name: users_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.users_id_seq OWNED BY public.users.id;


--
-- TOC entry 4647 (class 2604 OID 16446)
-- Name: applications id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.applications ALTER COLUMN id SET DEFAULT nextval('public.applications_id_seq'::regclass);


--
-- TOC entry 4650 (class 2604 OID 16469)
-- Name: users id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users ALTER COLUMN id SET DEFAULT nextval('public.users_id_seq'::regclass);


--
-- TOC entry 4809 (class 0 OID 16443)
-- Dependencies: 218
-- Data for Name: applications; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.applications (id, email, name, passport, address, migrant_name, migrant_passport, visa_number, migration_card, status, created_at, updated_at) FROM stdin;
\.


--
-- TOC entry 4811 (class 0 OID 16466)
-- Dependencies: 220
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.users (id, name, email, role, online, created_at, last_activity, password) FROM stdin;
2	ADMIN	ADMIN	Admin	f	2025-04-16 01:20:44.951347	2025-04-16 01:20:44.951347	1PR2HB+gqsU/T7flPDIPWpLapy3UEBf0zhJSQUcCNpo5+u4I
7	ADMINADMIN	ADMINADMINADMINADMIN	Admin	f	2025-04-16 02:28:44.990475	2025-04-16 02:28:44.990475	TROcZKHe/Uyz4yB2/OsTMdQ/VJr84QAqIOBo6gmP1JGgmLEw
1	ADMINADMIN	ADMINADMIN	Admin	f	2025-04-16 01:20:09.851691	2025-04-16 02:29:10.492529	cPs2HbkO1v9h+3nkfs8FCMYWqbKrJ57SxuyeDtVq0brhb+Nh
\.


--
-- TOC entry 4828 (class 0 OID 0)
-- Dependencies: 217
-- Name: applications_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.applications_id_seq', 1, false);


--
-- TOC entry 4829 (class 0 OID 0)
-- Dependencies: 219
-- Name: users_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_id_seq', 7, true);


--
-- TOC entry 4655 (class 2606 OID 16452)
-- Name: applications applications_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.applications
    ADD CONSTRAINT applications_pkey PRIMARY KEY (id);


--
-- TOC entry 4659 (class 2606 OID 16474)
-- Name: users users_email_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_email_key UNIQUE (email);


--
-- TOC entry 4661 (class 2606 OID 16472)
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (id);


--
-- TOC entry 4656 (class 1259 OID 16453)
-- Name: idx_applications_email; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX idx_applications_email ON public.applications USING btree (email);


--
-- TOC entry 4657 (class 1259 OID 16454)
-- Name: idx_applications_status; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX idx_applications_status ON public.applications USING btree (status);


--
-- TOC entry 4662 (class 2620 OID 16456)
-- Name: applications update_applications_timestamp; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER update_applications_timestamp BEFORE UPDATE ON public.applications FOR EACH ROW EXECUTE FUNCTION public.update_timestamp();


-- Completed on 2025-04-16 02:54:59

--
-- PostgreSQL database dump complete
--

