import itertools
#import itertools gia na dhmiourghsw ypolistes olwn twn pi8anwn syndiasmwn twn ari8mwn ths listas

def maxDistance() :
    finNumb = 0
    #me ayton ton tropo o xrhsths kanei input thn lista kanontas k ayto to programa ektelesimo xwris xrhsh cmd
    numbers = [int(x) for x in input("please enter a list of numbers. Use space to separate each number for each other \n").split()]
    print("Your list is :" , numbers)

    limit = input("Please type a number as a max limit \n")
    int(limit)

    for L in range(0, len(numbers) + 1):
        for subset in itertools.combinations(numbers, L):
            b = sum(subset)
            if b > finNumb and b <= int(limit):
                finNumb = b

    print("The closest sum of the list's numbers to : " , limit, " is : ", finNumb)
    end = input("please type anything to terminate the program \n")

    
maxDistance()