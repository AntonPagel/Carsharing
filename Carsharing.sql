DROP TABLE `car`;
DROP TABLE `user`;
DROP TABLE `location`;

CREATE TABLE `car` (
  `id` int(255) NOT NULL,
  `name` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `make` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `power` int(255) NOT NULL,
  `seats` int(255) NOT NULL,
  `trunksize` int(255) NOT NULL,
  `class` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `gearbox` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `fuel` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `coupling` tinyint(1) NOT NULL,
  `location_id` int(255) DEFAULT NULL,
  `reserved` DATE NOT NULL,
  `blocked` DATE NOT NULL,
  `reservedby` varchar(256),
  `blockedby` varchar(256)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE `location` (
  `id` int(255) NOT NULL,
  `postcode` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `city` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `street` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE `user` (
  `username` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `password` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `email` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `firstname` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `lastname` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `birthday` varchar(256) NOT NULL,
  `iban` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `admin` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;


ALTER TABLE `car`
  ADD PRIMARY KEY (`id`);

ALTER TABLE `location`
  ADD PRIMARY KEY (`id`);

ALTER TABLE `user`
  ADD PRIMARY KEY (`username`);
	

ALTER TABLE `car`
  MODIFY `id` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=0;

ALTER TABLE `location`
  MODIFY `id` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=0;


ALTER TABLE `car`
  ADD FOREIGN KEY (`location_id`) REFERENCES `location`(`id`);
ALTER TABLE `car`
  ADD FOREIGN KEY (`reservedby`) REFERENCES `user`(`username`);
ALTER TABLE `car`
  ADD FOREIGN KEY (`blockedby`) REFERENCES `user`(`username`);
  
INSERT INTO `location` (`postcode`, `city`, `street`) VALUES ('524289', 'Köln', 'Rektor-Klein-Str');

INSERT INTO `user` (`username`, `password`, `email`, `firstname`, `lastname`, `birthday`, `iban`, `admin`)
VALUES ('anton', '�Γ-\"�\'�H!���%?t�&9Pa����', 'iah51pagel@gso-koeln.de', 'Anton', 'Pagel', '30.08.2000', 'DE45 2738 4028 2787 12', '1');

INSERT INTO `user` (`username`, `password`, `email`, `firstname`, `lastname`, `birthday`, `iban`, `admin`)
VALUES ('otto', '�gB��\\v��U�g�6#ȳ��E��x��F�', 'otto@gmail.com', 'Otto', 'Müller', '12.01.1998', 'DE48 2539 1425 9825 45', '0');

INSERT INTO `car` (`name`, `make`, `power`, `seats`, `trunksize`, `class`, `gearbox`, `fuel`, `coupling`, `location_id`, `reserved`, `blocked`, `reservedby`, `blockedby`)
VALUES ('E 350 d AMG', 'Mercedes-Benz', '258', '4', '40', 'B', 'Automatik', 'Diesel', '0', '1', '2017-11-14 20:12:30', '2017-12-22 23:00:54', 'anton', 'anton');

INSERT INTO `car` (`name`, `make`, `power`, `seats`, `trunksize`, `class`, `gearbox`, `fuel`, `coupling`, `location_id`, `reserved`, `blocked`, `reservedby`, `blockedby`)
VALUES ('Passat', 'Volkswagen', '90', '4', '50', 'D', 'Manuell', 'Benzin', '1', '1', '2017-11-14 20:12:30', '2017-12-22 23:00:54', 'otto', 'otto');