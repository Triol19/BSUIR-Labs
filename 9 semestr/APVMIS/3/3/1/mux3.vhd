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

entity mux3 is
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
end mux3;

architecture Behavioral of mux3 is
begin 
logic: process(c, i0, i1, i2, i3, i4, i5, i6, i7)
begin
	if(c="000") then
		output <= i0;
	elsif(c="001") then
		output <= i1;
	elsif(c="010") then
		output <= i2;
	elsif(c="011") then
		output <= i3;
	elsif(c="100") then
		output <= i4;
	elsif(c="101") then
		output <= i5;
	elsif(c="110") then
		output <= i6;
	elsif(c="111") then
		output <= i7;
	else
		output <= 'Z';
end if;
end process;

end Behavioral;