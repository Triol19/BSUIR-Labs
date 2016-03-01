----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date:    17:12:32 09/11/2015 
-- Design Name: 
-- Module Name:    mux - Behavioral 
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

entity mux is
    Port ( i0 : in  STD_LOGIC;
           i1 : in  STD_LOGIC;
           i2 : in  STD_LOGIC;
           i3 : in  STD_LOGIC;
           i4 : in  STD_LOGIC;
           i5 : in  STD_LOGIC;
           i6 : in  STD_LOGIC;
           i7 : in  STD_LOGIC;
           c0 : in  STD_LOGIC;
           c1 : in  STD_LOGIC;
           c2 : in  STD_LOGIC;
           output : out  STD_LOGIC);
end mux;

architecture Behavioral of mux is

begin

logic: process(c0, c1, c2)
begin
	output <= (i0 and (not c0) and(not c1) and (not c2)) or
					(i1 and c0 and(not c1) and (not c2)) or
					(i2 and (not c0) and c1 and (not c2)) or
					(i3 and c0 and c1 and (not c2)) or
					(i4 and (not c0) and(not c1) and c2) or
					(i5 and c0 and(not c1) and c2) or
					(i6 and (not c0) and c1 and c2) or
					(i7 and c0 and c1 and c2);
end process;

end Behavioral;

