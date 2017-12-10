DROP TABLE `user`;
DROP TABLE `car`;
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
  `location_id` int(255) DEFAULT NULL
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