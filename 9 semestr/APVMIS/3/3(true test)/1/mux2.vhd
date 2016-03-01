----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date:    15:57:14 09/20/2015 
-- Design Name: 
-- Module Name:    mux2 - Behavioral 
-- Project Name: 
-- Target Devices: 
-- Tool versions: 
-- Description: 
--
-- Dependencies: 
--
-- Revision: 
-- Revision 0.01 - File Created
-- Additional Comments: 
--
----------------------------------------------------------------------------------
library IEEE;
use IEEE.STD_LOGIC_1164.ALL;

-- Uncomment the following library declaration if using
-- arithmetic functions with Signed or Unsigned values
--use IEEE.NUMERIC_STD.ALL;

-- Uncomment the following library declaration if instantiating
-- any Xilinx primitives in this code.
--library UNISIM;
--use UNISIM.VComponents.all;

entity mux2 is
	Port ( i0 : in  STD_LOGIC;
           i1 : in  STD_LOGIC;
           i2 : in  STD_LOGIC;
           i3 : in  STD_LOGIC;
           i4 : in  STD_LOGIC;
           i5 : in  STD_LOGIC;
           i6 : in  STD_LOGIC;
           i7 : in  STD_LOGIC;
           c : in  STD_LOGIC_VECTOR(2 downto 0);
           output : out  STD_LOGIC);
end mux2;

architecture Behavioral of mux2 is
begin
logic: process(c, i0, i1, i2, i3, i4, i5, i6, i7)
begin
	case c is
		when "000" =>
			output <= i0;
		when "001" =>
			output <= i1;
		when "010" =>
			output <= i2;
		when "011" =>
			output <= i3;
		when "100" =>
			output <= i4;
		when "101" =>
			output <= i5;
		when "110" =>
			output <= i6;
		when "111" =>
			output <= i7;
		when others =>
			output <= 'Z';
	end case;
end process;

end Behavioral;

