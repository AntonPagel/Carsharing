DROP TABLE car;
DROP TABLE location;
DROP TABLE user;

CREATE TABLE `car` (
  `id` int(50) NOT NULL,
  `name` TEXT COLLATE utf8mb4_unicode_ci NOT NULL,
  `make` TEXT COLLATE utf8mb4_unicode_ci NOT NULL,
  `power` int(255) NOT NULL,
  `seats` int(255) NOT NULL,
  `trunksize` int(255) NOT NULL,
  `class` TEXT COLLATE utf8mb4_unicode_ci NOT NULL,
  `gearbox` TEXT COLLATE utf8mb4_unicode_ci NOT NULL,
  `fuel` TEXT COLLATE utf8mb4_unicode_ci NOT NULL,
  `coupling` tinyint(1) NOT NULL,
  `location_id` int(255),
  `reserved` DATETIME NOT NULL,
  `blocked` DATETIME NOT NULL,
  `reservedby` varchar(50),
  `blockedby` varchar(50)
);

CREATE TABLE `location` (
  `id` int(255) NOT NULL,
  `postcode` TEXT COLLATE utf8mb4_unicode_ci NOT NULL,
  `city` TEXT COLLATE utf8mb4_unicode_ci NOT NULL,
  `street` TEXT COLLATE utf8mb4_unicode_ci NOT NULL
);

CREATE TABLE `user` (
  `username` varchar(255) NOT NULL,
  `password` TEXT COLLATE utf8mb4_unicode_ci NOT NULL,
  `email` TEXT COLLATE utf8mb4_unicode_ci NOT NULL,
  `firstname` TEXT COLLATE utf8mb4_unicode_ci NOT NULL,
  `lastname` TEXT COLLATE utf8mb4_unicode_ci NOT NULL,
  `birthday` TEXT COLLATE utf8mb4_unicode_ci  NOT NULL,
  `iban` TEXT COLLATE utf8mb4_unicode_ci NOT NULL,
  `admin` tinyint(1) NOT NULL
);


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
  
INSERT INTO `location` (`postcode`, `city`, `street`) VALUES ('', '', '');

INSERT INTO `user` (`username`, `password`, `email`, `firstname`, `lastname`, `birthday`, `iban`, `admin`) VALUES ('admin', "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", '', '', '', '', '', '1');