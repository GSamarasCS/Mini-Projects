
#variables
num = int(input("please enter a number from 1 to 1000000\n"))
x = float(num)
n = 0
prime = 2
nint = 0
counter = 0

#programm
print("The number " , num,  " can be divided in the following primes:  ")
while x != 1:
    n = x / prime
    #testers
    #print("1: ", n)
    nint = int(n)
    #testers
    #print("2: ", nint)
    if n == nint :
        x = n
        counter += 1
    else:
        if counter > 0:
            print(counter, " times ", prime, " multiplied by ")

        prime += 1
        counter = 0

print(counter, " times ", prime)
input("press anything to end the programm")